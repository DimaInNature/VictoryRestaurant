namespace Victory.Application.API.Features.UserRoles;

public sealed record class UpdateUserRoleCommand : IRequest
{
    public UserRoleEntity? UserRole { get; }

    public UpdateUserRoleCommand(UserRoleEntity entity) => UserRole = entity;

    public UpdateUserRoleCommand() { }
}