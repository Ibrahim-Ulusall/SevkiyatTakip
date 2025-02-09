using FluentValidation;
using Microsoft.AspNetCore.Http;
using Sevkiyat.Takip.Core.Models.Systems;

namespace Sevkiyat.Takip.Core.Middlewares;
public class ExceptionMiddleware
{
    private RequestDelegate _delegate;

    public ExceptionMiddleware(RequestDelegate @delegate)
    {
        _delegate = @delegate;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _delegate(context);
        }
        catch (Exception e)
        {
            await HandleException(context, e);
        }
    }

    private Task HandleException(HttpContext context, Exception e)
    {
        context.Response.ContentType = "application/json";

        var errorResponse = e switch
        {
            ValidationException validationException => HandleValidationException(context, validationException),
            SecurityExceptionModel securityException => HandleSecurityException(context, securityException),
            BusinessExceptionModel businessException => HandleBusinessException(context, businessException),
            _ => HandleGenericException(context, e)
        };

        return errorResponse;
    }

    private Task HandleValidationException(HttpContext context, ValidationException e)
    {
        context.Response.StatusCode = 400;
        var errors = e.Errors.Select(i => new ValidationExceptionModel
        {
            Property = i.PropertyName,
            Error = i.ErrorMessage
        }).ToList();

        var validationFailureErrors = new ValidationFailureErrors
        {
            StatusCode = context.Response.StatusCode,
            Errors = errors
        };

        return context.Response.WriteAsync(validationFailureErrors.ToString());
    }

    private Task HandleSecurityException(HttpContext context, SecurityExceptionModel e)
    {
        context.Response.StatusCode = 401;
        var errorDetail = new ErrorDetail
        {
            StatusCode = 401,
            Message = e.Message
        };

        return context.Response.WriteAsync(errorDetail.ToString());
    }

    private Task HandleBusinessException(HttpContext context, BusinessExceptionModel e)
    {
        context.Response.StatusCode = 400;
        var errorDetail = new ErrorDetail
        {
            StatusCode = 400,
            Message = e.Message
        };

        return context.Response.WriteAsync(errorDetail.ToString());
    }

    private Task HandleGenericException(HttpContext context, Exception e)
    {
        var errorDetail = new ErrorDetail
        {
            StatusCode = 500,
            Message = "Internal Server Error"
        };

        return context.Response.WriteAsync(errorDetail.ToString());
    }

}
