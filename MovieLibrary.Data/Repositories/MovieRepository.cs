using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Interfaces;

namespace MovieLibrary.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieLibraryContext _context;

        public MovieRepository(MovieLibraryContext context)
        {
            _context = context;
        }

        public Movie GetMovieById(int movieId)
        {
            return _context.Movies.Include(x => x.MovieCategories).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == movieId);
        }

        public int AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie.Id;
        }

        public void UpdateMovie(Movie movie)
        {
            _context.Attach(movie);
            _context.Update(movie);
            _context.SaveChanges();
        }

        public bool DeleteMovieById(int movieId)
        {
            var movie = _context.Movies.Find(movieId);
            if (movie == null) 
                return false;

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var movies = _context.Movies
                    .Include(x => x.MovieCategories).ThenInclude(x => x.Movie)
                    .Include(x => x.MovieCategories).ThenInclude(x => x.Category);
            return movies;
        }
    }
}
