using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MovieShop.MVC.Controllers {
    public class AccountController : Controller {
        private readonly IUserService _userService;

        public AccountController(IUserService userService) {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model) {
            var user = await _userService.RegisterUser(model);
            return View();
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model, string returnUrl=null) {
            if (string.IsNullOrEmpty(returnUrl)) {
                returnUrl ??= Url.Content("~/");
            }

            var user = await _userService.ValidateUser(model.Email, model.Password);
            if (user == null) {
                ModelState.AddModelError("", "Invalid Login Attempt");
                return View();
            }
            //continue for actual user
            //Cookie based authentication
            //once your service tells you that u entered correct username and password, application needs to create an authentication cookie that has some data and also expiration time
            //Don't store sensitive information inside it
            //Encrypt information that you want to store inside your cookie

            //movieshop.com/user/purchases => display all the movies purchased by user
            //User Controller
            //Purchases => should go to database, can only execute when user is logged in

            //Admin Controller
            //User should be logged in, user should have role of admin

            var claims = new List<Claim>{
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };
            //Identity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            //creating the cookie

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return LocalRedirect(returnUrl);
        }
    }
}
