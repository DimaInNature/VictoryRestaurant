namespace Victory.Consumers.Desktop.Domain.Commands.Users;

public sealed record class DeleteUserCommand
    : BaseAuthorizedFeature, IRequest
{
    public int Id { get; }

    public DeleteUserCommand(int id, string token) =>
        (Id, Token) = (id, token);

    public DeleteUserCommand() { }
}