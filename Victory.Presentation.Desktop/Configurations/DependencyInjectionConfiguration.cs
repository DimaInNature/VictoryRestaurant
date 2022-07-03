namespace Victory.Presentation.Desktop.Configurations;

internal static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddScoped<IFoodRepositoryService, FoodRepositoryService>();
        services.AddTransient<IFoodFacadeService, FoodFacadeService>();

        services.AddScoped<IFoodTypeRepositoryService, FoodTypeRepositoryService>();
        services.AddTransient<IFoodTypeFacadeService, FoodTypeFacadeService>();

        services.AddScoped<IUserRepositoryService, UserRepositoryService>();
        services.AddTransient<IUserFacadeService, UserFacadeService>();

        services.AddScoped<IUserRoleRepositoryService, UserRoleRepositoryService>();
        services.AddTransient<IUserRoleFacadeService, UserRoleFacadeService>();

        services.AddScoped<IBookingRepositoryService, BookingRepositoryService>();
        services.AddTransient<IBookingFacadeService, BookingFacadeService>();

        services.AddScoped<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();
        services.AddTransient<IMailSubscriberFacadeService, MailSubscriberFacadeService>();

        services.AddScoped<IContactMessageRepositoryService, ContactMessageRepositoryService>();
        services.AddTransient<IContactMessageFacadeService, ContactMessageFacadeService>();

        services.AddScoped<ITableRepositoryService, TableRepositoryService>();
        services.AddTransient<ITableFacadeService, TableFacadeService>();

        services.AddTransient<EmailService>();

        services.AddSingleton<UserSessionService>();

        services.AddSingleton<ImageUploaderService>();

        services.AddSingleton<APIFeaturesConfigurationService>();

        services.AddSingleton<SMTPConfigurationService>();
    }

    public static void AddViewModelsConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddTransient<LoginViewModel>();

        services.AddTransient<MainViewModel>();

        services.AddTransient<ReadFoodsViewModel>();
        services.AddTransient<CreateFoodsViewModel>();
        services.AddTransient<UpdateFoodsViewModel>();
        services.AddTransient<DeleteFoodsViewModel>();

        services.AddTransient<ReadUsersViewModel>();
        services.AddTransient<CreateUsersViewModel>();
        services.AddTransient<UpdateUsersViewModel>();
        services.AddTransient<DeleteUsersViewModel>();

        services.AddTransient<ReadBookingsViewModel>();
        services.AddTransient<DeleteBookingsViewModel>();

        services.AddTransient<ReadMailSubscribersViewModel>();
        services.AddTransient<DeleteMailSubscribersViewModel>();
        services.AddTransient<SendMailSubscribersViewModel>();

        services.AddTransient<ReadContactMessagesViewModel>();
        services.AddTransient<DeleteContactMessagesViewModel>();

        services.AddTransient<CreateTablesViewModel>();
        services.AddTransient<ReadTablesViewModel>();
        services.AddTransient<UpdateTablesViewModel>();
        services.AddTransient<DeleteTablesViewModel>();
    }
}