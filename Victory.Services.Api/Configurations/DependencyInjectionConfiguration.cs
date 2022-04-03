namespace Victory.Services.Api.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
        services.AddTransient<ICacheService<FoodEntity>, FoodMemoryCacheService>();
        services.AddTransient<IFoodFacadeService, FoodFacadeService>();

        services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
        services.AddTransient<ICacheService<BookingEntity>, BookingMemoryCacheService>();
        services.AddTransient<IBookingFacadeService, BookingFacadeService>();

        services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
        services.AddTransient<ICacheService<ContactMessageEntity>, ContactMessageMemoryCacheService>();
        services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();

        services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
        services.AddTransient<ICacheService<MailSubscriberEntity>, MailSubscriberMemoryCacheService>();
        services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

        services.AddTransient<IUserRepositoryService, UserRepositoryService>();
        services.AddTransient<ICacheService<UserEntity>, UserMemoryCacheService>();
        services.AddTransient<IUserFacadeService, UserFacadeService>();
    }
}