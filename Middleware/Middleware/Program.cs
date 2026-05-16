using Middleware.CustomMiddleware;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// app.Use is used to add middleware to the request pipeline.  app.Run is used to specify the terminal middleware that will handle the request and generate a response. In this example, we are using app.Use to add a middleware that writes "Done!" to the response and then calls the next middleware in the pipeline. We are also using app.Run to specify a terminal middleware that writes "Done!" to the response. When a request is made to the root URL ("/"), both middlewares will execute, resulting in "Done!Done!" being written to the response.



app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello from first middleware!");
    await next(context);
});

app.UseMyCustomMiddleWare();
app.UseHelloCustomMiddleware();

app.UseWhen(context => context.Request.Query.ContainsKey("Username"), app =>
{
    app.Use(async (context, next) =>
    {
        string username = context.Request.Query["Username"];

        await context.Response.WriteAsync("\n Hello from UseWhen Middlerwaer" + " " + $"{username}");
        await next(context);
    });
});

app.Run(async (HttpContext context) =>
{

    await context.Response.WriteAsync("\nDone! in terminal middleware");
});

app.Run();
