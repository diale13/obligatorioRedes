using DataAccess;
using DataAccess.Exceptions;
using Domain;
using IDataAccess;
using IServices;
using System;
using System.Collections.Generic;

namespace Services
{
    public class ApiUserService : MarshalByRefObject, IApiUserService
    {
        private IApiUsersDataAccess usersDataAccess = new ApiUsersDataAccess();
        private IMovieDataAccess movieDataAccess = new MovieDataAccess();

        public void AddUser(ApiUser user)
        {
            usersDataAccess.Add(user);
        }

        public bool DeleteUser(string nicknName, string password)
        {
            try
            {
                usersDataAccess.Delete(nicknName, password);
                return true;
            }
            catch (DataBaseException)
            {
                return false;
            }

        }

        public ApiUser GetUser(string nickName)
        {
            return usersDataAccess.Get(nickName);
        }

        public bool UpdateUser(ApiUser user)
        {
            try
            {
                usersDataAccess.Update(user);
                return true;
            }
            catch (DataBaseException)
            {
                return false;
            }

        }

        public bool AddFavoriteMovie(string nickName, string movieName)
        {
            try
            {
                var movieInDb = movieDataAccess.GetMovie(movieName);
                var userInDb = usersDataAccess.Get(nickName);

                if (!userInDb.FavoriteMovies.Contains(movieName))
                {
                    userInDb.FavoriteMovies.Add(movieName);
                }
                return true;

            }
            catch (DataBaseException)
            {
                return false;
            }

        }

        public bool RemoveFavoriteMovie(string nickName, string movieName)
        {
            var user = usersDataAccess.Get(nickName);
            if (user == null)
            {
                return false;
            }
            user.FavoriteMovies.Remove(movieName);
            return true;
        }

        public List<Movie> GetFavMovies(string nickName)
        {
            var user = usersDataAccess.Get(nickName);
            var favMovieNames = user.FavoriteMovies;
            var listOfActualMovies = new List<Movie>();
            foreach (var name in favMovieNames)
            {
                var movie = movieDataAccess.GetMovie(name);
                listOfActualMovies.Add(movie);
            }
            return listOfActualMovies;
        }

    }
}
