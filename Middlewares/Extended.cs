namespace AspNetFundamentals.Middlewares;

public static class ExtendedDemo
{
    public static IApplicationBuilder Demonstrate(this IApplicationBuilder app)
    {
        return app.UseMiddleware<Demo>();
    }
}