namespace AspNetFundamentals.Middlewares;

public class RequestQuery(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    public async Task InvokeAsync(HttpContext context)
    {
        await context.Response.WriteAsync($"Name: {context.Request.Query["name"]}");
        await _next(context);
    }
}

public static class RequestQueryExtension
{
    public static IApplicationBuilder UseRequestQuery(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RequestQuery>();
    }
}