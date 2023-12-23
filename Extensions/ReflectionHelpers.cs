namespace AppTemplate;

public static class ReflectionHelpers
{
    public static IEnumerable<Type> GetTypes(Type of)
    {
        return AppDomain
            .CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(
                a => a.IsAssignableTo(of) && !a.IsAbstract && !a.IsInterface
            );
    }
}
