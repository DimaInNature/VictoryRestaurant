namespace Victory.Presentation.Desktop.Configurations.MediatR.Profiles;

public static class UserAuthorizationMediatRProfile
{
    public static void AddUserAuthorizationMediatRProfile(this IServiceCollection services)
    {
        #region Commands

        // Authorization by Login and Password

        services.AddScoped<IRequest<string?>, UserAuthorizationCommand>();
        services.AddScoped<IRequestHandler<UserAuthorizationCommand, string?>, UserAuthorizationCommandHandler>();

        #endregion
    }
}