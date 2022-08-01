namespace Victory.Consumers.Web.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddTransient(serviceType: typeof(ISyncCacheService<>), implementationType: typeof(InMemoryCacheService<>));

        services.AddTransient<IFoodService, FoodService>();
        services.Decorate<IFoodService, FoodLoggingService>();
        services.Decorate<IFoodService, FoodCacheService>();

        services.AddTransient<IBookingService, BookingService>();
        services.Decorate<IBookingService, BookingLoggingService>();
        services.Decorate<IBookingService, BookingCacheService>();

        services.AddTransient<IContactMessageService, ContactMessageService>();
        services.Decorate<IContactMessageService, ContactMessageLoggingService>();
        services.Decorate<IContactMessageService, ContactMessageCacheService>();

        services.AddTransient<IMailSubscriberService, MailSubscriberService>();
        services.Decorate<IMailSubscriberService, MailSubscriberLoggingService>();
        services.Decorate<IMailSubscriberService, MailSubscriberCacheService>();

        services.AddTransient<ITableService, TableService>();
        services.Decorate<ITableService, TableLoggingService>();
        services.Decorate<ITableService, TableCacheService>();

        services.AddSingleton<APIFeaturesConfigurationService>();
    }
}