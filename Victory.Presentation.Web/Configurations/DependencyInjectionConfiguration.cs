namespace Victory.Presentation.Web.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
        services.AddTransient<FoodRepositoryServiceLoggerDecorator>();
        services.AddTransient<ICacheService<Food>, FoodMemoryCacheService>();
        services.AddTransient<IFoodFacadeService, FoodFacadeService>();

        services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
        services.AddTransient<BookingRepositoryServiceLoggerDecorator>();
        services.AddTransient<ICacheService<Booking>, BookingMemoryCacheService>();
        services.AddTransient<IBookingFacadeService, BookingFacadeService>();

        services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
        services.AddTransient<ContactMessageRepositoryServiceLoggerDecorator>();
        services.AddTransient<ICacheService<ContactMessage>, ContactMessageMemoryCacheService>();
        services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();

        services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
        services.AddTransient<MailSubscriberRepositoryServiceLoggerDecorator>();
        services.AddTransient<ICacheService<MailSubscriber>, MailSubscriberMemoryCacheService>();
        services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

        services.AddTransient<IUserRepositoryService, UserRepositoryService>();
        services.AddTransient<UserRepositoryServiceLoggerDecorator>();
        services.AddTransient<ICacheService<User>, UserMemoryCacheService>();
        services.AddTransient<IUserFacadeService, UserFacadeService>();
    }
}