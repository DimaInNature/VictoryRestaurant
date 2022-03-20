namespace API.IoC.Injectors;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IFoodRepository, FoodRepository>();
        services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
        services.AddTransient<ICacheService<FoodEntity>, FoodMemoryCacheService>();
        services.AddTransient<IFoodFacadeService, FoodFacadeService>();

        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
        services.AddTransient<ICacheService<BookingEntity>, BookingMemoryCacheService>();
        services.AddTransient<IBookingFacadeService, BookingFacadeService>();

        services.AddScoped<IContactMessageRepository, ContactMessageRepository>();
        services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
        services.AddTransient<ICacheService<ContactMessageEntity>, ContactMessageMemoryCacheService>();
        services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();

        services.AddScoped<IMailSubscriberRepository, MailSubscriberRepository>();
        services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
        services.AddTransient<ICacheService<MailSubscriberEntity>, MailSubscriberMemoryCacheService>();
        services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddTransient<IUserRepositoryService, UserRepositoryService>();
        services.AddTransient<ICacheService<UserEntity>, UserMemoryCacheService>();
        services.AddTransient<IUserFacadeService, UserFacadeService>();
    }
}