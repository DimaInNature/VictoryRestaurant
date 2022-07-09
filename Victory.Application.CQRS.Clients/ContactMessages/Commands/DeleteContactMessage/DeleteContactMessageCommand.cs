namespace Victory.Application.CQRS.Clients.ContactMessages;

public sealed record class DeleteContactMessageCommand
    : BaseAuthorizedFeature, IRequest
{
    public int Id { get; }

    public DeleteContactMessageCommand(int id, string token) =>
        (Id, Token) = (id, token);

    public DeleteContactMessageCommand() { }
}