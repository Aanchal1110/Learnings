using System.Runtime.CompilerServices;

namespace Middleware.CustomMiddleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nHello from Custom Middleware");
            await next(context);
            await context.Response.WriteAsync("\nBye from Custom Middleware");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseMyCustomMiddleWare(this IApplicationBuilder app)
        {
             return app.UseMiddleware<MyCustomMiddleware>();
        }

    }
}
