namespace Victory.Application.General.Client.Features.Users;

public sealed record class UpdateUserCommand : IRequest
{
    public User? User { get; }

    public UpdateUserCommand(User entity) => User = entity;

    public UpdateUserCommand() { }
}