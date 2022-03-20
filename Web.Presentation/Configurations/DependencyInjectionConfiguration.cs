namespace Web.Presentation.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        NativeInjectorBootStrapper.RegisterServices(services);
    }
}