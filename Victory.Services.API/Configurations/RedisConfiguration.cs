namespace Victory.Services.API.Configurations;

public static class RedisConfiguration
{
    public static void AddRedisConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddSingleton<IConnectionMultiplexer>(
            implementationFactory: x => ConnectionMultiplexer.Connect(
            configuration: builder.Configuration["RedisConnection"]));
    }
}