namespace Victory.Application.CQRS.API.Users;

public sealed record class DeleteUserCommand : IRequest
{
    public int Id { get; }

    public DeleteUserCommand(int id) => Id = id;

    public DeleteUserCommand() { }
}