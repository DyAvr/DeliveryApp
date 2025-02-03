using System.Net;
using Microsoft.EntityFrameworkCore;
using Versta.DeliveryApp.Domain.Exceptions;
using Versta.DeliveryApp.Infrastructure.Exceptions;

namespace Versta.DeliveryApp.Web.Middlewares;

public class ErrorHandlingMiddleware(
    RequestDelegate next,
    IWebHostEnvironment environment
)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var errorResponse = new ErrorResponse();

        switch (exception)
        {
            case DbUpdateException { InnerException: { } innerException }:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse.Message = innerException.Message;
                errorResponse.StackTrace = environment.IsDevelopment() ? innerException.StackTrace : null;
                break;

            case OrderNotFoundException:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                errorResponse.Message = exception.Message;
                errorResponse.StackTrace = environment.IsDevelopment() ? exception.StackTrace : null;
                break;

            case DomainException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Message = exception.Message;
                errorResponse.StackTrace = environment.IsDevelopment() ? exception.StackTrace : null;
                break;

            case ArgumentException:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Message = exception.Message;
                errorResponse.StackTrace = environment.IsDevelopment() ? exception.StackTrace : null;
                break;

            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse.Message =
                    environment.IsDevelopment() ? exception.Message : "Произошла непредвиденная ошибка.";
                errorResponse.StackTrace = environment.IsDevelopment() ? exception.StackTrace : null;
                break;
        }

        await context.Response.WriteAsJsonAsync(errorResponse);
    }
}