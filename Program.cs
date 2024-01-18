using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

var app = WebApplication.CreateBuilder().Build();

app.Use(async (context, next) => {
    var log = context.Request.Path.ToString();
    Console.WriteLine(log);
    await next.Invoke();
});
app.Run(async context => {
    await context.Response.WriteAsync("Hello World!");
});
app.Run();
