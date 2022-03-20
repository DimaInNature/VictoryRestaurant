namespace VictoryRestaurant.API.Configurations;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, WebApplicationBuilder builder)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<ApplicationContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
        });
    }
}