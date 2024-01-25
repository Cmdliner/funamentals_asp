using AspNetFundamentals.Middlewares;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseRouting();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    Endpoint? endpoint = context.GetEndpoint();
    if (endpoint.DisplayName != null)
    {
        await context.Response.WriteAsync($"{endpoint.DisplayName}\n");
    }
    await next(context);
});
// Conditional middleware
app.UseWhen((context) => context.Request.Query.ContainsKey("name"), app => app.UseRequestQuery());

app.UseEndpoints(endpoint =>
{
    // Define routes
    _ = endpoint.MapGet("/Home", async (context) => await context.Response.WriteAsync("You are in homepage"));
});


app.Run();