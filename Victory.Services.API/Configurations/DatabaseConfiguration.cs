namespace Victory.Services.API.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
    {
        if (builder is null) throw new ArgumentNullException(nameof(builder));

        services.AddDbContextPool<ApplicationContext>(options =>
        {
            // Enable Lazy Loading
            options.UseLazyLoadingProxies();

            // Set Connection String

            options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
        });
    }
}