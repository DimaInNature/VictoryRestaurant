namespace Victory.Application.CQRS.API.UserRoles;

public sealed record class CreateUserRoleCommand : IRequest
{
    public UserRoleEntity? UserRole { get; }

    public CreateUserRoleCommand(UserRoleEntity entity) => UserRole = entity;

    public CreateUserRoleCommand() { }
}