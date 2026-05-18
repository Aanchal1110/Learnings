var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.Map("map1",async (context) =>
//{
//   await context.Response.WriteAsync("Hello World");
//});

//app.Map("map2", (context) =>
//{
//    return context.Response.WriteAsync("Hellow from map2");
//});

app.MapGet("/files/{filename}.{extension}", async (context) =>
{
    string? filename=Convert.ToString(context.Request.RouteValues["filename"]);
   string? extensionname=Convert.ToString( context.Request.RouteValues["extension"]);

    await context.Response.WriteAsync($"The name of the file is {filename} - {extensionname}");

});

//giving a default route parameter value

app.Map("/product/productDetails/{id=4}",async context =>
{
    string id=Convert.ToString(context.Request.RouteValues["id"]);
    await context.Response.WriteAsync($"Product details of product with id - {id}");
});

//Making the route parameter's value an optional
app.Map("/employeeDetails/{id?}", async(context) =>
{
    
    if (context.Request.RouteValues.ContainsKey("id"))
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Employee Id is - {id}");
    }
    else
    {
        await context.Response.WriteAsync("Employee id is null");
    }
});


app.Map("/employeeDetails/{id:int:length(3,5)}", async (context) =>
{

    if (context.Request.RouteValues.ContainsKey("id"))
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);
        await context.Response.WriteAsync($"Employee Id is - {id}");
    }
    else
    {
        await context.Response.WriteAsync("Employee id is null");
    }
});


//Giving route parameter a constraint
app.Map("/daily-digest-report/{date:datetime}", async(context) =>
{
    DateTime date = Convert.ToDateTime(context.Request.RouteValues["date"]);
    await context.Response.WriteAsync($"Date that we got throught the url is {date}");
});

//giving a guid constraint can be created by clicking on tools
app.Map("/cities/{citiId:guid}", async(contex) =>
{
   Guid citiId= Guid.Parse(Convert.ToString(contex.Request.RouteValues["citiId"])!);
    await contex.Response.WriteAsync($"CitiId is - {citiId}");
});





app.MapFallback(async (context) =>
{
    await context.Response.WriteAsync($"No route matched at {context.Request.Path}");
});



app.Run();
