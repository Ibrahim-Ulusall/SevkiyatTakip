using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sevkiyat.Takip.Core.Utilities.Helpers;

namespace Sevkiyat.Takip.Core.Extensions;
public static class CoreExtension
{
    public static IServiceCollection AddCoreLayerDependencyResolvers(this IServiceCollection services)
    {
        services.AddSingleton<Helper>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        
        ServiceHelper.Create(services);

        return services;
    }
}
