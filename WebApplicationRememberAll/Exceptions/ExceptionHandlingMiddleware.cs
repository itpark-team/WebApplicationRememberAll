using WebApplicationRememberAll.Dtos;

namespace WebApplicationRememberAll.Exceptions;

public class ExceptionHandlingMiddleware
{
    private RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, 500, "Common exception", ex.Message, 500);
        }
    }
    
    private async Task HandleExceptionAsync(HttpContext httpContext, int httpCode, string title, string message,
        int code)
    {
        HttpResponse response = httpContext.Response;

        response.ContentType = "application/json";
        response.StatusCode = httpCode;

        ExceptionResponseDto exceptionDto = new ExceptionResponseDto()
        {
            Code = code,
            Title = title,
            Message = message
        };

        await response.WriteAsJsonAsync(exceptionDto);
    }
}