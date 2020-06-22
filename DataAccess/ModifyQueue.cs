using DataAccess.Exceptions;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ModifyQueue
    {

        private static ModifyQueue queueInstance;

        private List<string> genreNamesQueue;
        private List<string> movieNamesQueue;
        private List<string> direcorNamesQueue;


        private Object movieQueueLocker;
        private Object genreQueueLocker;
        private Object directorQueueLocker;



        private ModifyQueue()
        {
            this.genreNamesQueue = new List<string>();
            this.movieNamesQueue = new List<string>();
            this.direcorNamesQueue = new List<string>();

            this.movieQueueLocker = new object();
            this.genreQueueLocker = new object();
            this.directorQueueLocker = new object();
        }


        public void ChckAndAddToMovieList(string movieToCheck)
        {
            lock (movieQueueLocker)
            {
                int indexToCheck = movieNamesQueue.FindIndex(movieNameInList => movieNameInList.Equals(movieToCheck));
                if (indexToCheck == -1)
                {
                    movieNamesQueue.Add(movieToCheck);
                }
                else
                {
                    throw new EntityBeingModifiedException("Se ingereso una pelicula que esta siendo modificada, espere unos minutos y vuelva a intentar");
                }
            }
        }

        public void RemoveMovieFromModifyQueue(string movieThatWasModified)
        {
            lock (movieQueueLocker)
            {
                this.movieNamesQueue.Remove(movieThatWasModified);
            }

        }

        public void ChckAndAddToGenreList(string genreToCheck)
        {
            lock (genreQueueLocker)
            {
                int indexToCheck = genreNamesQueue.FindIndex(genreNameInList => genreNameInList.Equals(genreToCheck));
                if (indexToCheck == -1)
                {
                    genreNamesQueue.Add(genreToCheck);
                }
                else
                {
                    throw new EntityBeingModifiedException("Se ingereso un genero que esta siendo modificado, espere unos minutos y vuelva a intentar");
                }
            }
        }

        public void RemoveGenreFromQueue(string genreModified)
        {
            lock (genreQueueLocker)
            {
                this.genreNamesQueue.Remove(genreModified);
            }
        }

        public void ChckAndAddToDirectorList(string directorToCheck)
        {
            lock (directorQueueLocker)
            {
                int indexToCheck = direcorNamesQueue.FindIndex(dirNameInList => dirNameInList.Equals(directorToCheck));
                if (indexToCheck == -1)
                {
                    direcorNamesQueue.Add(directorToCheck);
                }
                else
                {
                    throw new EntityBeingModifiedException("Se ingereso un director que esta siendo modificado, espere unos minutos y vuelva a intentar");
                }
            }
        }

        public void RemoveDirectorFromQueue(string dirModified)
        {
            lock (directorQueueLocker)
            {
                this.direcorNamesQueue.Remove(dirModified);
            }
        }


        public static ModifyQueue GetInstance()
        {
            if (queueInstance == null)
            {
                queueInstance = new ModifyQueue();
                return queueInstance;
            }
            else
            {
                return queueInstance;
            }
        }





    }
}
