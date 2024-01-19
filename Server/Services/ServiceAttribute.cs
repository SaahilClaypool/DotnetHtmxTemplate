namespace AppTemplate;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public sealed class ServiceAttribute : Attribute
{
    public ServiceType ServiceType { get; set; } = ServiceType.Scoped;
    public Type? InterfaceType { get; set; }

    public static void RegisterServices(IServiceCollection serviceCollection)
    {
        var serviceAttrs = AppDomain
            .CurrentDomain.GetAssemblies()
            .SelectMany(a =>
                a.GetTypes()
                    .SelectMany(type =>
                        type.GetCustomAttributes(typeof(ServiceAttribute), true)
                            .Cast<ServiceAttribute>()
                            .Select(x => (type, attribute: x))
                    )
            );

        foreach (var (type, attr) in serviceAttrs)
        {
            var interfaceType = attr.InterfaceType ?? type;
            switch (attr.ServiceType)
            {
                case ServiceType.Singleton:
                    serviceCollection.TryAddSingleton(interfaceType, type);
                    break;
                case ServiceType.Scoped:
                    serviceCollection.TryAddScoped(interfaceType, type);
                    break;
                case ServiceType.Transient:
                    serviceCollection.TryAddTransient(interfaceType, type);
                    break;
            }
        }
    }
}

public enum ServiceType
{
    Singleton,
    Scoped,
    Transient
}
