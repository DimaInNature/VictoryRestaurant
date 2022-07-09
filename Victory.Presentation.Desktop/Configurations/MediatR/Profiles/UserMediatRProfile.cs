namespace Victory.Presentation.Desktop.Configurations.MediatR.Profiles;

public static class UserMediatRProfile
{
    public static void AddUserMediatRProfile(this IServiceCollection services)
    {
        #region Queries

        // Get User by Login

        services.AddScoped<IRequest<User?>, GetUserByLoginQuery>();
        services.AddScoped<IRequestHandler<GetUserByLoginQuery, User?>, GetUserByLoginQueryHandler>();

        // Get User by Login And Password

        services.AddScoped<IRequest<User?>, GetUserByLoginAndPasswordQuery>();
        services.AddScoped<IRequestHandler<GetUserByLoginAndPasswordQuery, User?>, GetUserByLoginAndPasswordQueryHandler>();

        // Get List<User>

        services.AddScoped<IRequest<List<User>?>, GetUserListQuery>();
        services.AddScoped<IRequestHandler<GetUserListQuery, List<User>?>, GetUserListQueryHandler>();

        #endregion

        #region Commands

        // Create

        services.AddScoped<IRequest<User?>, CreateUserCommand>();
        services.AddScoped<IRequestHandler<CreateUserCommand, User?>, CreateUserCommandHandler>();

        // Update by Id

        services.AddScoped<IRequest, UpdateUserCommand>();
        services.AddScoped<IRequestHandler<UpdateUserCommand, Unit>, UpdateUserCommandHandler>();

        // Delete by Id

        services.AddScoped<IRequest, DeleteUserCommand>();
        services.AddScoped<IRequestHandler<DeleteUserCommand, Unit>, DeleteUserCommandHandler>();

        #endregion
    }
}