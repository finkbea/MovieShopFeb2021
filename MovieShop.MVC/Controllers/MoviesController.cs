using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Infrastructure.Services;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.MVC.Controllers {
    public class MoviesController : Controller {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService) { //injecting concrete type into constructor
            _movieService = movieService;
        }
        public async Task<IActionResult> Index() {
            //it will look for a view with name called Index (because the action method name is index)

            //return View();
            //return a different view like index2 or TestView
            //1. Viewbag 2. ViewData 3. ** Strongly Typed Models
            //send list of top 30 movies to the view
            // id, title, posterUrl
            //model is just for view, only create necessary properties
            //entities need all properties

            //ViewBag.PageTitle = "Top 30 Grossing Movies";
            var movies = await _movieService.Get30HighestGrossing();

            return View(movies);
        }

        //we want to show blank page with all the inputs
        [HttpGet]
        public IActionResult Create() {
            return View();
        }

        public async Task<IActionResult> Details(int id) {
            var movie = await _movieService.GetMovieAsync(id);
            return View(movie);
        }



        //recieve movie information from view when submitted
        [HttpPost]
        public IActionResult Create(MovieCreateRequestModel model) {
            _movieService.CreateMovie(model);
            return RedirectToAction("Index"); //goes back to Index
        }

        public async Task<IActionResult> Genre(int id) {
            var movie = await _movieService.GetMoviesByGenreAsync(id);
            return View(movie);
        }

        /*[HttpPost]
        public IActionResult Create(MovieCreateRequestModel model, string title, string abc, decimal budget) { //abc is null because it doesn't match any of the names in the view, title and budget would recieve their respective values
            _movieService.CreateMovie(model);
            return RedirectToAction("Index"); //goes back to Index
        }*/



    }
}
