var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// app.Use is used to add middleware to the request pipeline.  app.Run is used to specify the terminal middleware that will handle the request and generate a response. In this example, we are using app.Use to add a middleware that writes "Done!" to the response and then calls the next middleware in the pipeline. We are also using app.Run to specify a terminal middleware that writes "Done!" to the response. When a request is made to the root URL ("/"), both middlewares will execute, resulting in "Done!Done!" being written to the response.



app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Done!");
    await next(context);
});

app.Run(async (HttpContext context) =>
{

    await context.Response.WriteAsync(" Done! in terminal middleware");
});

app.Run();
