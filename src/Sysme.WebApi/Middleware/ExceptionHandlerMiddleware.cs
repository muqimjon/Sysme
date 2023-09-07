using Sysme.Service.Exceptions;
using Sysme.WebApi.Models;

namespace Sysme.Web.Middleware;

public class ExceptionHandlerMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> logger;
    private readonly RequestDelegate request;

    public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
    {
        this.request = request;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await request.Invoke(context);
        }
        catch (NotFoundException ex)
        {
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = ex.StatusCode,
                Message = ex.Message,
            });
        }
        catch (AlreadyExistException ex)
        {
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = ex.StatusCode,
                Message = ex.Message,
            });
        }
        catch (Exception ex)
        {
            await context.Response.WriteAsJsonAsync(new Response
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message,
            });
            logger.LogError(ex.ToString());
        }
    }
}
