namespace Web.IoC.Injectors;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddSingleton<IFoodRepository, FoodRepository>();
        services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
        services.AddTransient<FoodRepositoryServiceLoggerDecorator>();
        services.AddTransient<ICacheService<Food>, FoodMemoryCacheService>();
        services.AddTransient<IFoodFacadeService, FoodFacadeService>();

        services.AddSingleton<IBookingRepository, BookingRepository>();
        services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
        services.AddTransient<BookingRepositoryServiceLoggerDecorator>();
        services.AddTransient<ICacheService<Booking>, BookingMemoryCacheService>();
        services.AddTransient<IBookingFacaceService, BookingFacadeService>();

        services.AddSingleton<IContactMessageRepository, ContactMessageRepository>();
        services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
        services.AddTransient<ContactMessageRepositoryServiceLoggerDecorator>();
        services.AddTransient<ICacheService<ContactMessage>, ContactMessageMemoryCacheService>();
        services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();

        services.AddTransient<IMailSubscriberRepository, MailSubscriberRepository>();
        services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
        services.AddTransient<MailSubscriberRepositoryServiceLoggerDecorator>();
        services.AddTransient<ICacheService<MailSubscriber>, MailSubscriberMemoryCacheService>();
        services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddTransient<IUserRepositoryService, UserRepositoryService>();
        services.AddTransient<UserRepositoryServiceLoggerDecorator>();
        services.AddTransient<ICacheService<User>, UserMemoryCacheService>();
        services.AddTransient<IUserFacadeService, UserFacadeService>();

        services.AddSingleton<IAuthorizationService, AuthorizationService>();
    }
}