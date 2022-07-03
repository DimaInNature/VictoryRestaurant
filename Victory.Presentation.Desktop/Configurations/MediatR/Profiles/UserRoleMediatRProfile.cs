namespace Victory.Presentation.Desktop.Configurations.MediatR.Profiles;

public static class UserRoleMediatRProfile
{
    public static void AddUserRoleMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get UserRole by Id

        services.AddScoped<IRequest<UserRole?>, GetUserRoleByIdQuery>();
        services.AddScoped<IRequestHandler<GetUserRoleByIdQuery, UserRole?>, GetUserRoleByIdQueryHandler>();

        // Get List<UserRole>

        services.AddScoped<IRequest<List<UserRole>?>, GetUserRoleListQuery>();
        services.AddScoped<IRequestHandler<GetUserRoleListQuery, List<UserRole>?>, GetUserRoleListQueryHandler>();

        #endregion

    }
}