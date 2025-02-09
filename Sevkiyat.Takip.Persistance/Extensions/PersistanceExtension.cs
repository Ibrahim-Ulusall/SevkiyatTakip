using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sevkiyat.Takip.Persistance.Contexts;
using System.Reflection;

namespace Sevkiyat.Takip.Persistance.Extensions;
public static class PersistanceExtension
{
    public static IServiceCollection AddPersistanceLayerDependencyResolvers(this IServiceCollection services
        , IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection")
                                    ?? throw new ArgumentNullException("Connection string not found");

        Assembly assembly = Assembly.GetExecutingAssembly();
        services.AddDbContext<SevkiyatContext>(opt =>
        {
            opt.UseNpgsql(connectionString);
        });

        services.AddAutoMapper(assembly);

        return services;
    }
}
//scaffold-dbcontext "Host=127.0.0.1;Database=sevkiyat;Username=postgres;Password=postgres;Port=5432" Npgsql.EntityFrameworkCore.PostgreSQL -Context "AppDbContext" -force -contextDir "Contexts" -outputdir "Contexts\Data" -NoOnConfiguring