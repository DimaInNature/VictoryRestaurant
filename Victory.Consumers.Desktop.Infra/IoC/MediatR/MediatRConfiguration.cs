namespace Victory.Consumers.Desktop.Infra.IoC.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        services.AddFoodMediatRProfile();

        services.AddFoodTypeMediatRProfile();

        services.AddBookingMediatRProfile();

        services.AddContactMessageMediatRProfile();

        services.AddMailSubscriberMediatRProfile();

        services.AddUserMediatRProfile();

        services.AddUserRoleMediatRProfile();

        services.AddCloudinaryImageMediatRProfile();

        services.AddTableMediatRProfile();

        services.AddSmtpApiMediatRProfile();

        services.AddUserAuthorizationMediatRProfile();
    }
}