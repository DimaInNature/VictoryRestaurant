namespace Victory.Consumers.Desktop.Domain.Commands.Users;

public sealed record class CreateUserCommand
    : BaseAnonymousFeature, IRequest<User?>
{
    public User? User { get; }

    public CreateUserCommand(User entity) => User = entity;

    public CreateUserCommand() { }
}