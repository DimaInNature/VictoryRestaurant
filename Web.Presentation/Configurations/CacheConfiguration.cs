namespace Web.Presentation.Configurations;

public static class CacheConfiguration
{
    public static void AddCacheConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddMemoryCache();
        services.TryAdd(descriptor: ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());
    }
}