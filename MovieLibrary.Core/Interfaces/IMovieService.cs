using System.Collections.Generic;
using MovieLibrary.Core.Models.MovieModel;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Interfaces
{
    public interface IMovieService
    {
        MovieDetailsModel GetMovieById(int movieId);
        int AddMovie(NewMovieModel movie);
        void UpdateMovie(UpdateMovieModel movie);
        bool DeleteMovieById(int movieId);

        IList<MovieDetailsModel> GetFilteredMoviesByTitle(string movieTitle);
        IList<MovieDetailsModel> GetFilteredMoviesByCategories(int[] categoriesId);
        IList<MovieDetailsModel> GetFilteredMoviesByRank(decimal minImdb, decimal maxImdb);
    }
}
