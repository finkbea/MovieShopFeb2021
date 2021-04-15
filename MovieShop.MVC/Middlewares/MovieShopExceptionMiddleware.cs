using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Helpers;
using ApplicationCore.Exceptions;
using System.Net;
using Serilog;

namespace MovieShop.MVC.Middlewares {
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MovieShopExceptionMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext) {
            try {
                await _next(httpContext);
            }
            catch (Exception ex) {
                _logger.LogError("Middleware is catching exception");
                await HandleExceptionAsync(httpContext, ex);
            }


            
        }
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex) {
            //get all the information you wanna log and use Serilog or NLog to log exceptions to text/json files
            _logger.LogError("Starting logging for exception");

            var errorModel = new ErrorResponseModel
            {
                ExceptionMessage = ex.Message,
                ExceptionStackTrace = ex.StackTrace,
                InnerExceptionMessage = ex.InnerException?.Message
                //could put email and other data pieces from the response model in here
            };

            switch (ex) {
                case ConflictException conflictException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                case NotFoundException notFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UnauthorizedAccessException unauthorized:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case Exception exception:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            //seriLog to log error model
            //send email also
            //redirect to error page
            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}
