namespace Victory.Consumers.Desktop.Domain.Commands.Tables;

public sealed record class DeleteTableCommand
    : BaseAuthorizedFeature, IRequest
{
    public int Id { get; }

    public DeleteTableCommand(int id, string token) => (Id, Token) = (id, token);

    public DeleteTableCommand() { }
}