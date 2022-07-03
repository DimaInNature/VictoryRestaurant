namespace Victory.Services.API.Configurations.MediatR.Profiles;

public static class UserRoleMediatRProfile
{
    public static void AddUserRoleMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get UserRoleEntity by Id

        services.AddScoped<IRequest<UserRoleEntity?>, GetUserRoleByIdQuery>();
        services.AddScoped<IRequestHandler<GetUserRoleByIdQuery, UserRoleEntity?>, GetUserRoleByIdQueryHandler>();

        // Get List<UserRoleEntity>

        services.AddScoped<IRequest<List<UserRoleEntity>?>, GetUserRoleListQuery>();
        services.AddScoped<IRequestHandler<GetUserRoleListQuery, List<UserRoleEntity>?>, GetUserRoleListQueryHandler>();

        // Get List<UserRoleEntity> by Name

        services.AddScoped<IRequest<List<UserRoleEntity>?>, GetUserRoleListByNameQuery>();
        services.AddScoped<IRequestHandler<GetUserRoleListByNameQuery, List<UserRoleEntity>?>, GetUserRoleListByNameQueryHandler>();

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