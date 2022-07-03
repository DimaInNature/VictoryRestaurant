namespace Victory.Application.CQRS.API.Tables;

public sealed record class CreateTableCommand : IRequest
{
    public TableEntity? Table { get; }

    public CreateTableCommand(TableEntity entity) => Table = entity;

    public CreateTableCommand() { }
}