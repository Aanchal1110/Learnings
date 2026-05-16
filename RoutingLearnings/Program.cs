var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("map1",async (context) =>
{
   await context.Response.WriteAsync("Hello World");
});

app.Map("map2", (context) =>
{
    return context.Response.WriteAsync("Hellow from map2");
});

app.MapFallback((context) =>
{
    return context.Response.WriteAsync("Fallback");
});



app.Run();
