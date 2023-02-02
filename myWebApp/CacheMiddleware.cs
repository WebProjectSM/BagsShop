using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace myWebApp
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CacheMiddleware
    {
        private readonly RequestDelegate _next;

        public CacheMiddleware(RequestDelegate next )
        {
            _next = next;
        }

        public  async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.GetTypedHeaders().CacheControl =
               new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
   {
       Public = true,
       MaxAge = TimeSpan.FromSeconds(20)
   };
            httpContext.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
            new string[] { "Accept-Encoding" };
            

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCacheMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CacheMiddleware>();
        }
    }
}
