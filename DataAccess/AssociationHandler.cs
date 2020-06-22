using DataAccess.Exceptions;
using Domain;
using IDataAccess;
using Persistance;
using System.Collections.Generic;

namespace DataAccess
{
    public class AssociationHandler : IAsociationHandler
    {
        private ModifyQueue queue = ModifyQueue.GetInstance();
        private object associationLock = new object();

        private List<Genre> genres = MemoryDataBase.GetInstance().Genres;
        private List<Movie> movies = MemoryDataBase.GetInstance().Movies;
        private List<Director> directors = MemoryDataBase.GetInstance().Directors;



        public void UpdateMovieAndGenre(Movie mov, Genre gen)
        {
            lock (associationLock)
            {
                var movieName = mov.Name;
                var genreName = gen.Name;
                try
                {
                    queue.ChckAndAddToMovieList(movieName);
                    queue.ChckAndAddToGenreList(genreName);

                    UpdateGenreAfterAsociation(gen);
                    UpdateMovieAfterASociation(mov);
                }
                catch (EntityBeingModifiedException entitiyBeingMod)
                {
                    RemoveMovieAndGenreFromQueue(genreName, movieName);
                    throw entitiyBeingMod;
                }
                catch (DataBaseException entityNotFound)
                {
                    RemoveMovieAndGenreFromQueue(genreName, movieName);
                    throw entityNotFound;
                }
                RemoveMovieAndGenreFromQueue(genreName, movieName);
            }
        }


        private void UpdateMovieAfterASociation(Movie mov)
        {
            var indexToModify = movies.FindIndex(movInList => movInList.Name.Equals(mov.Name));
            if (indexToModify == -1)
            {
                throw new DataBaseException("No se encontro el genero solicitado");
            }
            movies[indexToModify] = mov;
        }

        private void UpdateGenreAfterAsociation(Genre gen)
        {
            var indexToModify = genres.FindIndex(genInList => genInList.Name.Equals(gen.Name));
            if (indexToModify == -1)
            {
                throw new DataBaseException("No se encontro el genero solicitado");
            }
            genres[indexToModify] = gen;
        }


        private void UpdateDirectorAfterAsociation(Director dir)
        {
            var indexToModify = directors.FindIndex(dirInList => dirInList.Name.Equals(dir.Name));
            if (indexToModify == -1)
            {
                throw new DataBaseException("No se encontro el director solicitado");
            }
            directors[indexToModify] = dir;
        }



        private void RemoveDirectorAndMovieFromQueue(string movieName, string dirName)
        {
            queue.RemoveMovieFromModifyQueue(movieName);
            queue.RemoveDirectorFromQueue(dirName);
        }


        private void RemoveMovieAndGenreFromQueue(string genreName, string movieName)
        {
            queue.RemoveMovieFromModifyQueue(movieName);
            queue.RemoveGenreFromQueue(genreName);
        }


        public void UpdateMovieDirector(Movie movie, Director director)
        {
            lock (associationLock)
            {
                var movieName = movie.Name;
                var dirName = director.Name;
                try
                {
                    queue.ChckAndAddToMovieList(movieName);
                    queue.ChckAndAddToDirectorList(dirName);
                    
                    UpdateMovieAfterASociation(movie);
                    UpdateDirectorAfterAsociation(director);
                   
                }
                catch (EntityBeingModifiedException entitiyBeingMod)
                {
                    RemoveDirectorAndMovieFromQueue(movieName, dirName);
                    throw entitiyBeingMod;
                }
                catch (DataBaseException entityNotFound)
                {
                    RemoveDirectorAndMovieFromQueue(movieName, dirName);
                    throw entityNotFound;
                }
                RemoveDirectorAndMovieFromQueue(movieName, dirName);
            }
        }


        //TODO DIRECTOR AND MOVIE

    }
}
