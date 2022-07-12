namespace Victory.Presentation.Desktop.Configurations;

internal static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddScoped<IFoodRepositoryService, FoodRepositoryService>();

        services.AddScoped<IFoodTypeRepositoryService, FoodTypeRepositoryService>();

        services.AddScoped<IUserRepositoryService, UserRepositoryService>();

        services.AddScoped<IUserRoleRepositoryService, UserRoleRepositoryService>();

        services.AddScoped<IBookingRepositoryService, BookingRepositoryService>();

        services.AddScoped<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();

        services.AddScoped<IContactMessageRepositoryService, ContactMessageRepositoryService>();

        services.AddScoped<ITableRepositoryService, TableRepositoryService>();

        services.AddTransient<EmailService>();

        services.AddSingleton<UserSessionService>();

        services.AddSingleton<ImageUploaderService>();

        services.AddSingleton<APIFeaturesConfigurationService>();

        services.AddSingleton<SMTPConfigurationService>();

        services.AddTransient<JWTAuthorizationService>();
    }

    public static void AddViewModelsConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.Scan(action: scan =>
            scan.FromAssemblyOf<BaseViewModel>()
        .AddClasses(action: classes =>
            classes.Where(predicate: type =>
                type.Name.EndsWith(value: "ViewModel"))));
    }
}