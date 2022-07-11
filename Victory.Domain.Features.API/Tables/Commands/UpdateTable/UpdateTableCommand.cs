namespace Victory.Domain.Features.API.Tables;

public sealed record class UpdateTableCommand : IRequest
{
    public TableEntity? Table { get; }

    public UpdateTableCommand(TableEntity entity) => Table = entity;

    public UpdateTableCommand() { }
}