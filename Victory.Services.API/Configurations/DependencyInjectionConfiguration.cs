namespace Victory.Services.API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddTransient(serviceType: typeof(IAsyncCacheService<>), implementationType: typeof(RedisCacheService<>));

        services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
        services.Decorate<IFoodRepositoryService, FoodRepositoryCacheService>();

        services.AddTransient<IFoodTypeRepositoryService, FoodTypeRepositoryService>();
        services.Decorate<IFoodTypeRepositoryService, FoodTypeRepositoryCacheService>();

        services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
        services.Decorate<IBookingRepositoryService, BookingRepositoryCacheService>();

        services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
        services.Decorate<IContactMessageRepositoryService, ContactMessageRepositoryCacheService>();

        services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
        services.Decorate<IMailSubscriberRepositoryService, MailSubscriberRepositoryCacheService>();

        services.AddTransient<IUserRepositoryService, UserRepositoryService>();
        services.Decorate<IUserRepositoryService, UserRepositoryCacheService>();

        services.AddTransient<IUserRoleRepositoryService, UserRoleRepositoryService>();
        services.Decorate<IUserRoleRepositoryService, UserRoleRepositoryCacheService>();

        services.AddTransient<ITableRepositoryService, TableRepositoryService>();
        services.Decorate<ITableRepositoryService, TableRepositoryCacheService>();
    }
}