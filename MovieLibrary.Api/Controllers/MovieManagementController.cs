using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core.Interfaces;
using MovieLibrary.Core.Models.MovieModel;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.WebApi.Controllers
{
    [ApiController]
    [Route("/swagger/v1/[controller]")]
    public class MovieManagementController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieManagementController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<MovieDetailsModel> GetMovie(int movieId)
        {
            var movie = _movieService.GetMovieById(movieId);
            if (movie == null)
                return NotFound("Invalid movie ID");

            return Ok(movie);
        }

        [HttpPost]
        public ActionResult<int> AddMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data!");

            var movieId = _movieService.AddMovie(movie);

            return Ok($"Movie Id: {movieId}");
        }

        [HttpPut]
        public ActionResult UpdateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data!");
        
            _movieService.UpdateMovie(movie);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteMovie(int movieId)
        {
            var result = _movieService.DeleteMovieById(movieId);
            if (result == false)
                return NotFound();

            return Ok();
        }
    }
}
