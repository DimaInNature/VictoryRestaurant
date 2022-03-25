namespace VictoryRestaurant.API.Configurations.MediatR.Profiles;

public static class UserMediatRProfile
{
    public static void AddUserMediatRProfile(this IServiceCollection services!!)
    {
        #region Queries

        // Get UserEntity by Id

        services.AddScoped<IRequest<UserEntity?>, GetUserByIdQuery>();
        services.AddScoped<IRequestHandler<GetUserByIdQuery, UserEntity?>, GetUserByIdQueryHandler>();

        // Get UserEntity by Login

        services.AddScoped<IRequest<UserEntity?>, GetUserByLoginQuery>();
        services.AddScoped<IRequestHandler<GetUserByLoginQuery, UserEntity?>, GetUserByLoginQueryHandler>();

        // Get UserEntity by Login And Password

        services.AddScoped<IRequest<UserEntity?>, GetUserByLoginAndPasswordQuery>();
        services.AddScoped<IRequestHandler<GetUserByLoginAndPasswordQuery, UserEntity?>, GetUserByLoginAndPasswordQueryHandler>();

        // Get List<UserEntity>

        services.AddScoped<IRequest<List<UserEntity>?>, GetUserListQuery>();
        services.AddScoped<IRequestHandler<GetUserListQuery, List<UserEntity>?>, GetUserListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest, CreateUserCommand>();
        services.AddScoped<IRequestHandler<CreateUserCommand, Unit>, CreateUserCommandHandler>();

        // Update by Id

        services.AddScoped<IRequest, UpdateUserCommand>();
        services.AddScoped<IRequestHandler<UpdateUserCommand, Unit>, UpdateUserCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteUserCommand>();
        services.AddScoped<IRequestHandler<DeleteUserCommand, Unit>, DeleteUserCommandHandler>();

        #endregion
    }
}