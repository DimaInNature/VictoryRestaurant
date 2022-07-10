namespace Victory.Services.API.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddTransient<IFoodRepositoryService, FoodRepositoryService>();
        services.AddTransient<ICacheService<FoodEntity>, RedisCacheService<FoodEntity>>();
        services.AddTransient<IFoodFacadeService, FoodFacadeService>();

        services.AddTransient<IFoodTypeRepositoryService, FoodTypeRepositoryService>();
        services.AddTransient<ICacheService<FoodTypeEntity>, RedisCacheService<FoodTypeEntity>>();
        services.AddTransient<IFoodTypeFacadeService, FoodTypeFacadeService>();

        services.AddTransient<IBookingRepositoryService, BookingRepositoryService>();
        services.AddTransient<ICacheService<BookingEntity>, RedisCacheService<BookingEntity>>();
        services.AddTransient<IBookingFacadeService, BookingFacadeService>();

        services.AddTransient<IContactMessageRepositoryService, ContactMessageRepositoryService>();
        services.AddTransient<ICacheService<ContactMessageEntity>, RedisCacheService<ContactMessageEntity>>();
        services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();

        services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
        services.AddTransient<ICacheService<MailSubscriberEntity>, RedisCacheService<MailSubscriberEntity>>();
        services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

        services.AddTransient<IUserRepositoryService, UserRepositoryService>();
        services.AddTransient<ICacheService<UserEntity>, RedisCacheService<UserEntity>>();
        services.AddTransient<IUserFacadeService, UserFacadeService>();

        services.AddTransient<IUserRoleRepositoryService, UserRoleRepositoryService>();
        services.AddTransient<ICacheService<UserRoleEntity>, RedisCacheService<UserRoleEntity>>();
        services.AddTransient<IUserRoleFacadeService, UserRoleFacadeService>();

        services.AddTransient<ITableRepositoryService, TableRepositoryService>();
        services.AddTransient<ICacheService<TableEntity>, RedisCacheService<TableEntity>>();
        services.AddTransient<ITableFacadeService, TableFacadeService>();
    }
}