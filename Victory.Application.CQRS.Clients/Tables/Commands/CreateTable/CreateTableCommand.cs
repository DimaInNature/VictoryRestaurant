namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class CreateTableCommand : IRequest
{
    public Table? Table { get; }

    public CreateTableCommand(Table entity) => Table = entity;

    public CreateTableCommand() { }
}