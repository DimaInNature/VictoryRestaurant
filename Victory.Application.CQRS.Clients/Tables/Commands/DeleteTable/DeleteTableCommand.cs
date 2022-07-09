namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class DeleteTableCommand
    : BaseAuthorizedFeature, IRequest
{
    public int Id { get; }

    public DeleteTableCommand(int id, string token) => (Id, Token) = (id, token);

    public DeleteTableCommand() { }
}