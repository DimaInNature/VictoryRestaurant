namespace Desktop.IoC.Injectors;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IFoodRepository, FoodRepository>();
        services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
        services.AddTransient<IFoodFacadeService, FoodFacadeService>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddTransient<IUserRepositoryService, UserRepositoryService>();
        services.AddTransient<IUserFacadeService, UserFacadeService>();

        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
        services.AddTransient<IBookingFacadeService, BookingFacadeService>();

        services.AddScoped<IMailSubscriberRepository, MailSubscriberRepository>();
        services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
        services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

        services.AddScoped<IContactMessageRepository, ContactMessageRepository>();
        services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
        services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();
    }
}