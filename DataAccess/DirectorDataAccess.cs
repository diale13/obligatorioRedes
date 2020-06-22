using DataAccess.Exceptions;
using Domain;
using IDataAccess;
using Persistance;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class DirectorDataAccess : IDirectorDataAccess
    {
        private List<Director> directors = MemoryDataBase.GetInstance().Directors;
        private readonly Object directorsLock = new object();
        ModifyQueue queue = ModifyQueue.GetInstance();

        public void AddDirector(Director director)
        {
            lock (directorsLock)
            {  
                if (IsNameUnique(director.Name))
                {
                    directors.Add(director);
                }
                else
                {
                    throw new DataBaseException("Ya existe un director con ese nombre");
                }
            }
        }

        private bool IsNameUnique(string name)
        {
            var validationInt = directors.FindIndex(dir => dir.Name.Equals(name));
            return (validationInt == -1);
        }



        public void DeleteDirector(string directorName)
        {
            queue.ChckAndAddToDirectorList(directorName);
            lock (directorsLock)
            {
                var indexToDelete = directors.FindIndex(dir => dir.Name.Equals(directorName));
                if (indexToDelete == -1)
                {
                    queue.RemoveDirectorFromQueue(directorName);
                    throw new DataBaseException("No se encontro el director solicitado");
                }
                directors.RemoveAt(indexToDelete);
            }
            queue.RemoveDirectorFromQueue(directorName);
        }

        public List<Director> GetDirectors()
        {
            lock (directorsLock)
            {
                return directors;
            }
        }

        public void UpdateDirector(string currentName, Director updatedDirector)
        {
            queue.ChckAndAddToDirectorList(currentName);
            lock (directorsLock)
            {
                var indexToModify = directors.FindIndex(dir => dir.Name.Equals(currentName));
                if (indexToModify == -1)
                {
                    queue.RemoveDirectorFromQueue(currentName);
                    throw new DataBaseException("No se encontro el director solicitado");
                }
                directors[indexToModify] = updatedDirector;
            }
            queue.RemoveDirectorFromQueue(currentName);
        }

        public Director GetDirector(string name)
        {
            lock (directorsLock)
            {
                var indexToReturn = directors.FindIndex(dir => dir.Name.Equals(name));
                if (indexToReturn == -1)
                {
                    throw new DataBaseException("No se encontro el director solicitado");
                }
                return directors[indexToReturn];
            }
        }
    }
}