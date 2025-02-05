using Microsoft.AspNetCore.Builder;
using Sevkiyat.Takip.Core.Middlewares;

namespace Sevkiyat.Takip.Core.Extensions;
public static class ExceptionMiddlewareExtension
{
    public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}
