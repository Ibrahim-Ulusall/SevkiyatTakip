using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sevkiyat.Takip.Persistance.Contexts;
using System.Reflection;

namespace Sevkiyat.Takip.Persistance.Extensions;
public static class PersistanceExtension
{
    public static IServiceCollection AddPersistanceDependencyInjection(this IServiceCollection services
        , IConfiguration configuration)
    {

        Assembly assembly = Assembly.GetExecutingAssembly();

        services.AddDbContext<SevkiyatContext>(opt =>
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")
                                        ?? throw new ArgumentNullException("Connection string not found");

            opt.UseNpgsql(connectionString);
        });

        services.AddDbContext<UserDbContext>(opt =>
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")
                                        ?? throw new ArgumentNullException("Connection string not found");

            opt.UseNpgsql(connectionString);
        });


        var repositories = assembly.GetTypes().Where(i => i.IsClass && !i.IsAbstract
                && i.GetInterfaces().Any(i => i.Name == $"I{i.Name}")).ToList();

        foreach (var repository in repositories)
        {
            var interfaces = repository.GetInterfaces().Where(i => i.Name == $"I{i.Name}");
            foreach (var @interface in interfaces)
                services.AddScoped(@interface, repository);
        }

        return services;
    }
}
