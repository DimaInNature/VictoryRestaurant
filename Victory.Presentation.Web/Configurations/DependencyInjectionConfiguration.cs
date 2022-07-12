namespace Victory.Presentation.Web.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddTransient(serviceType: typeof(ISyncCacheService<>), implementationType: typeof(InMemoryCacheService<>));

        services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
        services.Decorate<IFoodRepositoryService, FoodRepositoryLoggingService>();
        services.Decorate<IFoodRepositoryService, FoodRepositoryCacheService>();

        services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
        services.Decorate<IBookingRepositoryService, BookingRepositoryLoggingService>();
        services.Decorate<IBookingRepositoryService, BookingRepositoryCacheService>();

        services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
        services.Decorate<IContactMessageRepositoryService, ContactMessageRepositoryLoggingService>();
        services.Decorate<IContactMessageRepositoryService, ContactMessageRepositoryCacheService>();

        services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
        services.Decorate<IMailSubscriberRepositoryService, MailSubscriberRepositoryLoggingService>();
        services.Decorate<IMailSubscriberRepositoryService, MailSubscriberRepositoryCacheService>();

        services.AddTransient<IUserRepositoryService, UserRepositoryService>();
        services.Decorate<IUserRepositoryService, UserRepositoryLoggingService>();
        services.Decorate<IUserRepositoryService, UserRepositoryCacheService>();

        services.AddTransient<ITableRepositoryService, TableRepositoryService>();
        services.Decorate<ITableRepositoryService, TableRepositoryLoggingService>();
        services.Decorate<ITableRepositoryService, TableRepositoryCacheService>();

        services.AddSingleton<APIFeaturesConfigurationService>();
    }
}