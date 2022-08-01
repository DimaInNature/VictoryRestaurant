namespace Victory.Microservices.SMTP.Infra.IoC;

public static class DependencyInjectionConfiguration
{
    public static void RegisterServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddTransient<IGenericRepository<MailSubscriberEntity>, GenericRepository<MailSubscriberEntity>>();

        services.AddTransient<IMailSubscriberService, MailSubscriberService>();

        services.AddTransient<ISMTPService, SMTPService>();
    }
}