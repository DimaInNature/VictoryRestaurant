namespace Victory.Application.API.Features.Tables;

public sealed record class UpdateTableCommand : IRequest
{
    public TableEntity? Table { get; }

    public UpdateTableCommand(TableEntity entity) => Table = entity;

    public UpdateTableCommand() { }
}