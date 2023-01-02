using Microsoft.Extensions.Options;
using Platform;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MessagOptions>(options =>
{
    options.CityName = "San Diego";
});
var app = builder.Build();

app.MapGet("/location", async (HttpContext context,
        IOptions<MessagOptions> msgOpts) =>
{
    Platform.MessagOptions opts = msgOpts.Value;
    await context.Response.WriteAsync($"{opts.CityName}, {opts.CountryName}");
});

//((IApplicationBuilder)app).Map("/branch", branch =>
//{

//    branch.Run(new Platform.QueryStringMiddleWare().Invoke);
//    //The Map method is used to create a section of pipeline that is used to process requests for specific 
//    //URLS, creating a separate sequence of middleware components

//    //branch.Use(async (HttpContext context, Func<Task> next) =>
//    //branch.Run(async(context) =>
//    //{
//    //    await context.Response.WriteAsync($"Branch Middleware");
//    //});
//});

//app.Use(async (context, next) =>
//{
//    //immediately calls the next method to pass the request along the pipleline and then uses 
//    //writeAsync method to add a string to the response body.
//    //This allows middleware to make changes to the response before and after it is passed along
//    //the request pipeline by defining statements before and after the next function is invoked
//    await next();
//    await context.Response
//        .WriteAsync($"\nStatus Code: {context.Response.StatusCode}");
//});

//app.Use(async (context, next) =>
//{

//    //checks the Path property of the HttpRequest object to see whether the request is for the /short 
//    //URL; if it is , it calls writeAsync without calling the next function.
//    if (context.Request.Path == "/short")
//    {
//        await context.Response
//            .WriteAsync($"Request Short Circuited");
//    }
//    else
//    {
//        await next();
//    }
//});
//app.Use(async (context, next) =>
//{
//    //if the request is "Get" and custom then change the response type to plaintext and write response 
//    if (context.Request.Method == HttpMethods.Get
//        && context.Request.Query["custom"] == "true")
//    {
//        context.Response.ContentType = "text/plain";
//        await context.Response.WriteAsync("Custom Middleware \n");
//    }
//    await next();
//});

//app.UseMiddleware<Platform.QueryStringMiddleWare>();
app.MapGet("/", () => "Hello World!");


app.Run();
