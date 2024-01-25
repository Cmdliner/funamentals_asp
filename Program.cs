using AspNetFundamentals.Middlewares;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.UseRouting();

// Conditional middleware
app.UseWhen((context) => context.Request.Query.ContainsKey("name"), app => app.UseRequestQuery());

app.UseEndpoints(endpoint =>
{
    // Define routes
    _ = endpoint.MapGet("/Home", async (context) => await context.Response.WriteAsync("You are in homepage"));
});


app.Run();