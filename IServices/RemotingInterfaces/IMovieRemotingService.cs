using Domain;
using System.Collections.Generic;

namespace IServices
{
    public interface IMovieRemotingService
    {
        List<Movie> GetAllMovies();
        Movie GetMovie(string name);
    }
}
