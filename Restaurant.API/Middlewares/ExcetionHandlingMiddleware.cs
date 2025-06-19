using Restaurant.Domain.Exceptions;

namespace Restaurant.API.Middlewares;

public class ExcetionHandlingMiddleware( ILogger<ExcetionHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException e)
        {
            logger.LogWarning(e.Message);
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync(e.Message);
        }

        catch (Exception e)
        {
            logger.LogInformation(e.Message);
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Something went wrong");
        }
    }
}