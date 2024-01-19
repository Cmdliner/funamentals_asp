namespace AspNetFundamentals.Middlewares;
public class Demo: IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Before logic
        Console.WriteLine("Custom Middleware Started!");
        await context.Response.WriteAsync("\n");
        await next(context);
        // After logic
        Console.WriteLine("Custom Middleware finished!");
    }
}