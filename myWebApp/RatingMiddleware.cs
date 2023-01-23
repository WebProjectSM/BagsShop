using DataLayer;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace myWebApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RatingDL _ratingDL;

        public RatingMiddleware(RequestDelegate next,IRatingDL ratingDL)
        {
            _next = next;
        }

        public  Task Invoke(HttpContext httpContext)
        {
            _ratingDL.insertRatingTable(httpContext.Request.Host.ToString(), httpContext.Request.Method, httpContext.Request.Path, null, new DateTime().Date);
            return  _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
