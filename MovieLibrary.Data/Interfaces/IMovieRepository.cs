using System.Collections.Generic;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Data.Interfaces
{
    public interface IMovieRepository
    {
        Movie GetMovieById(int movieId);
        int AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        bool DeleteMovieById(int movieId);
        IEnumerable<Movie> GetAllMovies();
    }
}
