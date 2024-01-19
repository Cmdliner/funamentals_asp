namespace AspNetFundamentals.Middlewares;
 
public class Conventional(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public Task Invoke(HttpContext context)
    {
        return _next(context);
    }
}

public static class ConventionalExtensions
{
    public static IApplicationBuilder UseConventional(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<Conventional>();
    }
    
}