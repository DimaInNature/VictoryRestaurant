namespace Victory.Microservices.FoodService.Persistence.IoC;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        ArgumentNullException.ThrowIfNull(argument: configuration);

        services.AddScoped<DbContext, FoodServiceDbContext>();

        services.AddDbContextPool<FoodServiceDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString(name: "Sqlite"));
        });
    }
}