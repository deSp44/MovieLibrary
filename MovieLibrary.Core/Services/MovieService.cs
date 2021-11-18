using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Models.MovieModel;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Interfaces;

namespace MovieLibrary.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public MovieDetailsModel GetMovieById(int movieId)
        {
            var movie = _movieRepository.GetMovieById(movieId);
            var movieModel = _mapper.Map<MovieDetailsModel>(movie);
            return movieModel;
        }

        public int AddMovie(NewMovieModel movie)
        {
            var movieModel = _mapper.Map<Movie>(movie);
            return _movieRepository.AddMovie(movieModel);
        }

        public void UpdateMovie(UpdateMovieModel movie)
        {
            var movieModel = _mapper.Map<Movie>(movie);
            _movieRepository.UpdateMovie(movieModel);
        }

        public bool DeleteMovieById(int movieId)
        {
            return _movieRepository.DeleteMovieById(movieId);
        }

        public IList<MovieDetailsModel> GetFilteredMoviesByTitle(string movieTitle)
        {
            var listOfMovies = _movieRepository.GetAllMovies();
            var listOfMoviesDetail = listOfMovies.Select(movie => _mapper.Map<MovieDetailsModel>(movie));

            if (movieTitle != null)
            {
                var moviesFiltered = listOfMoviesDetail.Select(x => x).Where(x => x.Title.ToUpper().Contains(movieTitle.ToUpper())).OrderByDescending(x => x.ImdbRating).ToList();

                return moviesFiltered;
            }

            var fullListOfMovies = listOfMoviesDetail.OrderByDescending(x => x.ImdbRating).ToList();
            return fullListOfMovies;
        }

        public IList<MovieDetailsModel> GetFilteredMoviesByCategories(int[] categoriesId)
        {
            var listOfMovies = _movieRepository.GetAllMovies();
            var listOfMoviesDetail = listOfMovies.Select(movie => _mapper.Map<MovieDetailsModel>(movie));

            var moviesFiltered = (from categoryId in categoriesId from movie in listOfMoviesDetail from category in movie.Categories where category.Id == categoryId select movie).OrderByDescending(x => x.ImdbRating).ToList();

            return moviesFiltered;
        }

        public IList<MovieDetailsModel> GetFilteredMoviesByRank(decimal minImdb, decimal maxImdb)
        {
            var listOfMovies = _movieRepository.GetAllMovies();
            var listOfMoviesDetail = listOfMovies.Select(movie => _mapper.Map<MovieDetailsModel>(movie));

            var moviesFiltered = listOfMoviesDetail.Select(x => x).Where(x => x.ImdbRating >= minImdb && x.ImdbRating <= maxImdb).OrderByDescending(x => x.ImdbRating).ToList();

            return moviesFiltered;
        }
    }
}
