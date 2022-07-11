namespace Victory.Domain.Features.API.Tables;

public sealed record class CreateTableCommand : IRequest
{
    public TableEntity? Table { get; }

    public CreateTableCommand(TableEntity entity) => Table = entity;

    public CreateTableCommand() { }
}