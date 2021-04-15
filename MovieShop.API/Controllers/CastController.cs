using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers {
    [Route("api/[controller]/{id}")]
    [ApiController]
    public class CastController : ControllerBase {
        private readonly ICastService _castService;
        public CastController(ICastService castService) {
            _castService = castService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Details(int id) {
            var cast = await _castService.GetCastDetailsWithMovies(id);
            return Ok(cast);
        }
    }
}
