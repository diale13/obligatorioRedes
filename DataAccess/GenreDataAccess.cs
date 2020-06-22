using DataAccess.Exceptions;
using Domain;
using IDataAccess;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class GenreDataAccess : IGenreDataAccess
    {
        private List<Genre> genres = MemoryDataBase.GetInstance().Genres;
        private readonly Object genreLock = new object();
        ModifyQueue queue = ModifyQueue.GetInstance();

        public void Delete(Genre genreToDelete)
        {
            queue.ChckAndAddToGenreList(genreToDelete.Name);
            lock (genreLock)
            {
                var indexToDelete = genres.FindIndex(gen => gen.Name.Equals(genreToDelete.Name));
                if (indexToDelete == -1)
                {
                    queue.RemoveGenreFromQueue(genreToDelete.Name);
                    throw new DataBaseException("No se encontro el genero solicitado");
                }

                genres.RemoveAt(indexToDelete);
            }
            queue.RemoveGenreFromQueue(genreToDelete.Name);
        }
        public List<Genre> GetGenres()
        {
            lock (genreLock)
            {
                return genres;
            }
        }

        public bool Exists(string genre)
        {
            return genres.FindIndex(gen => gen.Name.Equals(genre)) != -1;
        }

        public void Update(string genreName, Genre updatedGenre)
        {
            queue.ChckAndAddToGenreList(genreName);
            lock (genreLock)
            {
                var indexToModify = genres.FindIndex(gen => gen.Name.Equals(genreName));
                if (indexToModify == -1)
                {
                    queue.RemoveGenreFromQueue(genreName);
                    throw new DataBaseException("No se encontro el genero solicitado");
                }
                genres[indexToModify] = updatedGenre;
            }
            queue.RemoveGenreFromQueue(genreName);
        }

        public void Upload(Genre genre)
        {
            lock (genreLock)
            {
                if (IsNameUnique(genre.Name))
                {
                    genres.Add(genre);
                }
                else
                {
                    throw new DataBaseException("Ya existe un genero con ese nombre");
                }
            }
        }

        public Genre GetGenre(string name)
        {
            lock (genreLock)
            {
                var indexToReturn = genres.FindIndex(gen => gen.Name.Equals(name));
                if (indexToReturn == -1)
                {
                    throw new DataBaseException("No se encontro el genero solicitado");
                }
                return genres[indexToReturn];
            }
        }

        private bool IsNameUnique(string name)
        {
            var validationInt = genres.FindIndex(gen => gen.Name.Equals(name));
            return (validationInt == -1);
        }




    }
}
