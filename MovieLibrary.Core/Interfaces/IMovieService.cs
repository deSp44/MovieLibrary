using System.Collections.Generic;
using MovieLibrary.Core.Models.MovieModel;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Interfaces
{
    public interface IMovieService
    {
        MovieDetailsModel GetMovieById(int movieId);
        int AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        bool DeleteMovieById(int movieId);

        IList<MovieDetailsModel> GetFilteredMoviesByTitle(string movieTitle);
        IList<MovieDetailsModel> GetFilteredMoviesByCategories(int[] categoriesId);
        IList<MovieDetailsModel> GetFilteredMoviesByRank(decimal minImdb, decimal maxImdb);
    }
}
