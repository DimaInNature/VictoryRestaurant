namespace Victory.Microservices.FoodService.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddTransient<IGenericRepository<FoodEntity>, GenericRepository<FoodEntity>>();

        services.AddTransient<IGenericRepository<FoodTypeEntity>, GenericRepository<FoodTypeEntity>>();

        services.AddTransient<IFoodAppService, FoodAppService>();

        services.AddTransient<IFoodTypeAppService, FoodTypeAppService>();
    }
}