namespace Core;
[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
public sealed class ServiceAttribute : Attribute
{
    public ServiceType ServiceType { get; set; } = ServiceType.Scoped;
    public Type? InterfaceType { get; set; }
}

public enum ServiceType
{
    Singleton,
    Scoped,
    Transient
}