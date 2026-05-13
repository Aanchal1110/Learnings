//So the HTTP context is a type of object that gets created automatically upon receiving the request.
//So when the browser sends a request to the Kestrel and the Kestrel forwards the same request to the application code to the ASP .NET Core application, then ASP.NET Core automatically creates an object of type HTTP context and this context contains the information related to your request, response and many more other details.

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    if (1 == 1)
    {
        context.Response.StatusCode = 400;
    }
    else
    {
        context.Response.StatusCode = 200;
    }
    await context.Response.WriteAsync("Hello");
    await context.Response.WriteAsync(" World");
});


//app.MapGet("/", () => "Hello World!");

app.Run();
