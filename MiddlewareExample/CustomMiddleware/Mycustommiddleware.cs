
using System.Runtime.CompilerServices;

namespace MiddlewareExample.CustomMiddleware
{
    public class Mycustommiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("My Custom Middleware Starts\n");
            await next(context);
            await context.Response.WriteAsync("My Custom Middleware End\n");
        }
    }
    public static class CustomMiddlewareExtension 
    {
        public static IApplicationBuilder UseMycustomMiddleware(this IApplicationBuilder app)
        {
           return app.UseMiddleware<Mycustommiddleware>();
        }

    }

}
