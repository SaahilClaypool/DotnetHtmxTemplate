using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AppTemplate;

public static class ServiceAttributeExtensions
{
    public static void RegisterServicesFromAttribute(
        this IServiceCollection serviceCollection
    )
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
