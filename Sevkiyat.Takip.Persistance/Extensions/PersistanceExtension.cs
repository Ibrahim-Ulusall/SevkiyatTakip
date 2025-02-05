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

        Assembly assembly = Assembly.GetExecutingAssembly();

        string connectionString = configuration.GetConnectionString("DefaultConnection")
                                    ?? throw new ArgumentNullException("Connection string not found");

        services.AddDbContext<SevkiyatContext>(opt =>
        {
            opt.UseNpgsql(connectionString);
        });

        var repositoryTypes = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}")).ToList();

        foreach (var repo in repositoryTypes)
        {
            var interfaces = repo.GetInterfaces().Where(i => i.Name == $"I{repo.Name}");
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, repo);
            }
        }

        return services;
    }
}
//scaffold-dbcontext "Host=127.0.0.1;Database=sevkiyat;Username=postgres;Password=postgres;Port=5432" Npgsql.EntityFrameworkCore.PostgreSQL -Context "AppDbContext" -force -contextDir "Contexts" -outputdir "Contexts\Data" -NoOnConfiguring