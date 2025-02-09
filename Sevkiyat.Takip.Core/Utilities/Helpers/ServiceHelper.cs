using Microsoft.Extensions.DependencyInjection;

namespace Sevkiyat.Takip.Core.Utilities.Helpers;
public static class ServiceHelper
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    public static IServiceCollection Create(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}
