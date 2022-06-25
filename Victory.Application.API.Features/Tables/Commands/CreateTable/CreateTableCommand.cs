namespace Victory.Application.API.Features.Tables;

public sealed record class CreateTableCommand : IRequest
{
    public TableEntity? Table { get; }

    public CreateTableCommand(TableEntity entity) => Table = entity;

    public CreateTableCommand() { }
}