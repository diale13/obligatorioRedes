using Domain;
using IServices;
using ServerAdmin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Filters;

namespace ServerAdmin.Controllers
{
    [RoutePrefix("movie")]
    public class MovieController : ApiController
    {
        private IMovieRemotingService movieLogic;
        public MovieController()
        {
            movieLogic = (IMovieRemotingService)Activator.GetObject(
         typeof(IMovieRemotingService), "tcp://127.0.0.1:4200/movieService");
        }


        [LogInFilter]
        [Route("")]
        public async Task<IHttpActionResult> GetAsync()
        {
            await Task.Yield();
            List<Movie> rawMovies = movieLogic.GetAllMovies();
            List<MovieModel> ret = new List<MovieModel>();
            foreach (var movie in rawMovies)
            {
                ret.Add(new MovieModel(movie));
            }
            return Ok(ret);
        }
        
    }
}
