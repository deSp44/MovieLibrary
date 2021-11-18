using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Models.MovieModel;

namespace MovieLibrary.WebApi.Controllers
{
    [ApiController]
    [Route("/swagger/v1/[controller]/Filter")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("Title")]
        public ActionResult<IList<MovieDetailsModel>> Filter(string movieTitle)
        {
            var movies = _movieService.GetFilteredMoviesByTitle(movieTitle);
            if (movies.Count == 0)
                return NotFound("Invalid movie title.");
            return Ok(movies);
        }

        [HttpGet]
        [Route("Categories")]
        public ActionResult<IList<MovieDetailsModel>> Filter([FromQuery] int[] categoriesId)
        {
            var movies = _movieService.GetFilteredMoviesByCategories(categoriesId);
            if (movies.Count == 0)
                return NotFound("No movies with that category.");
            return Ok(movies);
        }
        
        [HttpGet]
        [Route("RateRange")]
        public ActionResult<IList<MovieDetailsModel>> Filter(decimal minImdb, decimal maxImdb)
        {
            var movies = _movieService.GetFilteredMoviesByRank(minImdb, maxImdb);
            if (movies.Count == 0)
                return NotFound("No movies found on that rate range.");
            return Ok(movies);
        }
    }
}
