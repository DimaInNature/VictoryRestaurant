namespace Victory.Consumers.Desktop.Domain.Commands.ContactMessages;

public sealed record class DeleteContactMessageCommand
    : BaseAuthorizedFeature, IRequest
{
    public int Id { get; }

    public DeleteContactMessageCommand(int id, string token) =>
        (Id, Token) = (id, token);

    public DeleteContactMessageCommand() { }
}