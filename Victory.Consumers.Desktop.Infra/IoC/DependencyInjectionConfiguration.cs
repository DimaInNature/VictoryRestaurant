namespace Victory.Consumers.Desktop.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddScoped<IFoodService, FoodService>();

        services.AddScoped<IFoodTypeService, FoodTypeService>();

        services.AddScoped<IUserService, UserService>();

        services.AddScoped<IUserRoleService, UserRoleService>();

        services.AddScoped<IBookingService, BookingService>();

        services.AddScoped<IMailSubscriberService, MailSubscriberService>();

        services.AddScoped<IContactMessageService, ContactMessageService>();

        services.AddScoped<ITableService, TableService>();

        services.AddTransient<EmailService>();

        services.AddSingleton<UserSessionService>();

        services.AddSingleton<ImageUploaderService>();

        services.AddSingleton<APIFeaturesConfigurationService>();

        services.AddSingleton<SMTPConfigurationService>();

        services.AddTransient<JWTAuthorizationService>();
    }
}