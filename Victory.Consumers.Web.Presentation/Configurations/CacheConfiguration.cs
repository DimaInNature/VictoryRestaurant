﻿namespace Victory.Consumers.Web.Presentation.Configurations;

public static class CacheConfiguration
{
    public static void AddCacheConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddMemoryCache();
        services.TryAdd(descriptor: ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());
    }
}