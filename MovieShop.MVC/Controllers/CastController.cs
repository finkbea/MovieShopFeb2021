using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;

namespace MovieShop.MVC.Controllers {
    public class CastController : Controller {
        private readonly ICastService _castService;
        public CastController(ICastService castService) {
            _castService = castService;
        }

        public async Task<IActionResult> Details(int id) {
            var cast = await _castService.GetCastDetailsWithMovies(id);
            return View(cast);
        }
    }
}
