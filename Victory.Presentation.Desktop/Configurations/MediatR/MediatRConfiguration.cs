namespace Victory.Presentation.Desktop.Configurations.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        // Add features: ...

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