namespace API.Features.Users.Commands;

public sealed record class CreateUserCommand : IRequest
{
    public UserEntity? User { get; }

    public CreateUserCommand(UserEntity user!!) => User = user;

    public CreateUserCommand() { }
}