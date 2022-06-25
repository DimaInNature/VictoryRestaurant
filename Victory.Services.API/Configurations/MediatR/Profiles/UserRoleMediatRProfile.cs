namespace Victory.Services.API.Configurations.MediatR.Profiles;

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

        // Get List<UserRole> by Name

        services.AddScoped<IRequest<List<UserRole>?>, GetUserRoleListByNameQuery>();
        services.AddScoped<IRequestHandler<GetUserRoleListByNameQuery, List<UserRole>?>, GetUserRoleListByNameQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateUserRoleCommand>();
        services.AddScoped<IRequestHandler<CreateUserRoleCommand, Unit>, CreateUserRoleCommandHandler>();

        // Update by Id

        services.AddScoped<IRequest, UpdateUserRoleCommand>();
        services.AddScoped<IRequestHandler<UpdateUserRoleCommand, Unit>, UpdateUserRoleCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteUserRoleCommand>();
        services.AddScoped<IRequestHandler<DeleteUserRoleCommand, Unit>, DeleteUserRoleCommandHandler>();

        #endregion
    }
}