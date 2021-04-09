using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MovieShop.MVC.Controllers {
    public class UserController : Controller {

        [Authorize] //builtin filter
        [HttpGet]
        public async Task<IActionResult> GetUserPurchasedMovies() {
            //call user service by id for user to get all movies they purchased

            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchaseMovie() {
            //cal user service by id for user to get all movies they purchased
            return View();
        }
    }
}
