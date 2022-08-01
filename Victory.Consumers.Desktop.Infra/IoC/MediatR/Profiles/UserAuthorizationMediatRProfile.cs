namespace Victory.Consumers.Desktop.Infra.IoC.MediatR.Profiles;

internal static class UserAuthorizationMediatRProfile
{
    public static void AddUserAuthorizationMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        // Authorization by Login and Password

        services.AddScoped<IRequest<string?>, UserAuthorizationCommand>();
        services.AddScoped<IRequestHandler<UserAuthorizationCommand, string?>, UserAuthorizationCommandHandler>();

        #endregion
    }
}