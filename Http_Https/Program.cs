//So the HTTP context is a type of object that gets created automatically upon receiving the request.
//So when the browser sends a request to the Kestrel and the Kestrel forwards the same request to the application code to the ASP .NET Core application, then ASP.NET Core automatically creates an object of type HTTP context and this context contains the information related to your request, response and many more other details.

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    if (1 == 1)
    {
        context.Response.StatusCode = 400;
        string path = context.Request.Path;
        string method = context.Request.Method;
        //statusCode should be 200 but for learning purpose we are making it 400
        context.Response.Headers["MyKey"] = "my value";
        context.Response.Headers["Server"] = "My Server";
        context.Response.Headers["Content-Type"] = "text/html";

        await context.Response.WriteAsync($"<p>{path}</p>");
        await context.Response.WriteAsync($"<p>{method}</p>");

        //QueryString
        if (context.Request.Method == "GET")
        {
            if (context.Request.Query.ContainsKey("id"))
            {
                string id = context.Request.Query["id"];
                context.Response.WriteAsync($"<p>{id}</p>");
            }
        }

        //Request Header is a way in which browser communicates with the server and tells browser what and how to get the things
        if (context.Request.Headers.ContainsKey("User-Agent"))
        {
            string userAgent = context.Request.Headers["User-Agent"];
            await context.Response.WriteAsync($"<p>{userAgent}</p>");
        }
        
        
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
