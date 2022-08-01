namespace Victory.Consumers.Web.Infra.IoC.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        services.AddFoodMediatRProfile();

        services.AddBookingMediatRProfile();

        services.AddContactMessageMediatRProfile();

        services.AddMailSubscriberMediatRProfile();

        services.AddTableMediatRProfile();
    }
}