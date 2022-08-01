namespace Victory.Microservices.SMTP.Infra.IoC.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        services.AddMailSubscriberMediatRProfile();

        services.AddMailingMediatRProfile();
    }
}