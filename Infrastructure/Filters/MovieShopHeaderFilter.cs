using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Infrastructure.Filters {
    class MovieShopHeaderFilter : IActionFilter {
        private readonly ICurrentUserService _currentUserService;
        public MovieShopHeaderFilter(ICurrentUserService currentUserService) {
            _currentUserService = currentUserService;
        }
        public void OnActionExecuted(ActionExecutedContext context) {
            //log each and every users ip address, his name if authenticated, authentication status, date time
            //context.HttpContext.Response.Headers.Add("myhomepage", "antra.com");
            var email = _currentUserService.Email;
            var datetime = DateTime.UtcNow;
            var isAuthenticated = _currentUserService.IsAuthenticated;
            var name = _currentUserService.FullName;

            //log this info to text files, System.IO
        }

        public void OnActionExecuting(ActionExecutingContext context) {
            //int x = 20 / 10;
        }
    }
}
