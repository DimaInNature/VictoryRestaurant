namespace Victory.Consumers.Desktop.Domain.Commands.Tables;

public sealed record class CreateTableCommand
    : BaseAuthorizedFeature, IRequest
{
    public Table? Table { get; }

    public CreateTableCommand(Table entity, string token) =>
        (Table, Token) = (entity, token);

    public CreateTableCommand() { }
}