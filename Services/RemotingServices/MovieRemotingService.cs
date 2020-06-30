using DataAccess;
using DataAccess.Exceptions;
using Domain;
using IDataAccess;
using IServices;
using System;
using System.Collections.Generic;

namespace Services.RemotingServices
{
    public class MovieRemotingService : MarshalByRefObject, IMovieRemotingService
    {
        private IMovieDataAccess movieDataAcces = new MovieDataAccess();
        public List<Movie> GetAllMovies()
        {
            return movieDataAcces.GetMovies();
        }

        public Movie GetMovie(string name)
        {
            try
            {
                return movieDataAcces.GetMovie(name);

            }
            catch (DataBaseException)
            {
                return null;
            }
        }
    }
}
