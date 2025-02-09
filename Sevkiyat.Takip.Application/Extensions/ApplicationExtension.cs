using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Sevkiyat.Takip.Application.Utilities.Security.JWT;
using System.Reflection;

namespace Sevkiyat.Takip.Application.Extensions;
public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationLayerDependencyResolvers(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddSingleton<ITokenHelper, JwtHelper>();
        return services;
    }
}
