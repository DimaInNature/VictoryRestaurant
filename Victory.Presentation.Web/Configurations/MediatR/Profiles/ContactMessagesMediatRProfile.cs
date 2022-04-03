namespace Victory.Presentation.Web.Configurations.MediatR.Profiles;

public static class ContactMessageMediatRProfile
{
    public static void AddContactMessageMediatRProfile(this IServiceCollection services)
    {
        #region Commands

        // Create

        services.AddScoped<IRequest, CreateContactMessageCommand>();
        services.AddScoped<IRequestHandler<CreateContactMessageCommand, Unit>, CreateContactMessageCommandHandler>();

        #endregion
    }
}