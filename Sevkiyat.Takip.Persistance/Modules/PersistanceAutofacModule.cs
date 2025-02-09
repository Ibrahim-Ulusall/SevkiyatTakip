using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Sevkiyat.Takip.Core.Utilities.Interceptors;
using System.Reflection;

namespace Sevkiyat.Takip.Persistance.Modules;

public class PersistanceAutofacModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {

        Assembly assembly = Assembly.GetExecutingAssembly();

        var repositoryTypes = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}")).ToList();

        foreach (var repo in repositoryTypes)
        {
            var interfaces = repo.GetInterfaces().Where(i => i.Name == $"I{repo.Name}");
            foreach (var @interface in interfaces)
            {
                builder.RegisterType(repo).As(@interface).SingleInstance();
            }
        }

        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

    }
}