﻿using Microsoft.Extensions.DependencyInjection;
using Sevkiyat.Takip.Application.Utilities.Security.JWT;

namespace Sevkiyat.Takip.Application.Extensions;
public static class ApplicationExtension
{
    public static IServiceCollection AddApplicationLayerDependencyResolvers(this IServiceCollection services)
    {
        services.AddSingleton<ITokenHelper, JwtHelper>();
        return services;
    }
}
