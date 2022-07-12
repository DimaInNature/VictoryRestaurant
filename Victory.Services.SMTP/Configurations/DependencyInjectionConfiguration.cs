namespace Victory.Services.SMTP.Configurations;

public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddTransient<IMailSubscriberRepositoryService, MailSubscriberRepositoryService>();

        services.AddTransient<EmailMailingService>();

        services.AddSingleton<APIFeaturesConfigurationService>();

        services.AddSingleton<SMTPConfigurationService>();
    }
}