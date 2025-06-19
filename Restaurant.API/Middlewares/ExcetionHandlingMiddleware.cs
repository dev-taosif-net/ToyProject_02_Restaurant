namespace Restaurant.API.Middlewares;

public class ExcetionHandlingMiddleware( ILogger<ExcetionHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception e)
        {
            logger.LogInformation(e.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong");
        }
    }
}