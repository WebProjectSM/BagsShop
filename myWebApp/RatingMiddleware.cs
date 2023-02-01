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
        private readonly IRatingDL _ratingDL;

        public RatingMiddleware(RequestDelegate next,IRatingDL ratingDL)
        {
            _next = next;
            _ratingDL = ratingDL;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string Referer = httpContext.Request.Headers["Referer"];
            string UserAgent = httpContext.Request.Headers["User-Agent"];
            _ratingDL.InsertRatingTable(httpContext.Request.Host.ToString(), httpContext.Request.Method, httpContext.Request.Path, Referer, UserAgent, DateTime.Now);
            

           // Console.WriteLine(new DateTime().Date);
             await _next(httpContext);
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
