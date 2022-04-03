namespace Victory.Presentation.Desktop.Configurations.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        // Add features: ...

        services.AddFoodMediatRProfile();

        services.AddBookingMediatRProfile();

        services.AddContactMessageMediatRProfile();

        services.AddMailSubscriberMediatRProfile();

        services.AddUserMediatRProfile();
    }
}