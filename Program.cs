using AspNetFundamentals.Middlewares;

var builder = WebApplication.CreateBuilder();

// Dependency Injection
builder.Services.AddTransient<Demo>();

var app = builder.Build();

// Middlewares
app.Use(async (context, next) => 
{
    await context.Response.WriteAsync("Middleware 1");
    await next();
});

// Using the custom middleware
app.UseMiddleware<Demo>();

// Uses custom middleware directly
app.Demonstrate();

app.Use(async (context, next) => 
{
    await context.Response.WriteAsync("Middleware 3");
    await next();

});

// Conditional middleware
app.UseWhen((context) => context.Request.Query.ContainsKey("name"), app => app.UseRequestQuery());

// Use a custom middleware defined as per normal asp devs convention
app.UseConventional();

app.Run();