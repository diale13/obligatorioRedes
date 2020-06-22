using DataAccess.Exceptions;
using Domain;
using IDataAccess;
using Persistance;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class MovieDataAccess : IMovieDataAccess
    {
        private List<Movie> movies = MemoryDataBase.GetInstance().Movies;
        private readonly Object movieLock = new object();
        ModifyQueue queue = ModifyQueue.GetInstance();

        public void Delete(Movie movie)
        {
            queue.ChckAndAddToMovieList(movie.Name);
            lock (movieLock)
            {
                var indexToDelete = movies.FindIndex(mov => mov.Name.Equals(movie.Name));
                if (indexToDelete == -1)
                {
                    queue.RemoveMovieFromModifyQueue(movie.Name);
                    throw new DataBaseException("No se encontro la pelicula solicitada");
                }
                movies.RemoveAt(indexToDelete);                
            }
            queue.RemoveMovieFromModifyQueue(movie.Name);
        }

        public Movie GetMovie(string movieName)
        {
            lock (movieLock)
            {
                int indexToReturn = movies.FindIndex(mov => mov.Name.Equals(movieName));
                if (indexToReturn == -1)
                {
                    throw new DataBaseException("No se encontro la pelicula solicitada");
                }
                return movies[indexToReturn];
            }
        }

        public void Update(string movieName, Movie updatedMovie)
        {
            queue.ChckAndAddToMovieList(movieName);
            lock (movieLock)
            {
                var indexToModify = movies.FindIndex(mov => mov.Name.Equals(movieName));
                if (indexToModify == -1)
                {
                    queue.RemoveMovieFromModifyQueue(movieName);
                    throw new DataBaseException("No se encontro la pelicula solicitada");
                }
                movies[indexToModify] = updatedMovie;
            }
            queue.RemoveMovieFromModifyQueue(movieName);
        }
              

        public void Upload(Movie mov)
        {
            lock (movieLock)
            {
                var uniqueNameValidator = movies.FindIndex(movieInList => movieInList.Name.Equals(mov.Name));
                if (IsNameUnique(mov.Name))
                {
                    movies.Add(mov);
                }
                else
                {
                    throw new DataBaseException("Ya existe una pelicula con ese nombre");
                }
            }
        }

        private bool IsNameUnique(string name)
        {
            var validationInt = movies.FindIndex(movieInList => movieInList.Name.Equals(name));
            return (validationInt == -1);
        }

        public List<Movie> GetMovies()
        {
            lock (movieLock)
            {
                return movies;
            }
        }
    }
}
