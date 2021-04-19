using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService) { //injecting concrete type into constructor
            _movieService = movieService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index() {
            var movies = await _movieService.GetAll();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int id) {
            var movie = await _movieService.GetMovieAsync(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRated() {
            var movie = await _movieService.Get30HighestGrossing();
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopRevenue() {
            var movie = await _movieService.GetHighestGrossingMovies();
            return Ok(movie);
        }

        [HttpGet]
        [Route("genre/{genreId}")]
        public async Task<IActionResult> Genre(int genreId) {
            var movie = await _movieService.GetMoviesByGenreAsync(genreId);
            return Ok(movie);
        }

        [HttpGet]
        [Route("{id}/reviews")]
        public async Task<IActionResult> Reviews(int id) {
            var movie = await _movieService.GetReviewsForMovie(id);
            return Ok(movie);
        }

    }
}