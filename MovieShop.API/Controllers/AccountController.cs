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
    public class AccountController : ControllerBase {
        private readonly IUserService _userService;
        public AccountController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel requestModel) {
            if (!ModelState.IsValid) {
                return BadRequest("please check data");
            }
            var registeredUser = await _userService.RegisterUser(requestModel);
            return Ok(registeredUser);
        }

        /*[HttpGet]
        [Route("")]
        public async Task<>*/
    }
}
