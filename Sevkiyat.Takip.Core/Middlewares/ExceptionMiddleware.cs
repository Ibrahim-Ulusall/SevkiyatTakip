using Microsoft.AspNetCore.Http;
using Sevkiyat.Takip.Core.Models.Systems;
using System.Net;

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
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        string message = "Internal Server Error";

        return context.Response.WriteAsync(new ErrorDetail
        {
            Message = message,
            StatusCode = context.Response.StatusCode,

        }.ToString());

    }
}
