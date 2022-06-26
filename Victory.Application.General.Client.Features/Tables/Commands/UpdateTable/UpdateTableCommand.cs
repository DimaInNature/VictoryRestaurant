namespace Victory.Application.General.Client.Features.Tables;

public sealed record class UpdateTableCommand : IRequest
{
    public Table? Table { get; }

    public UpdateTableCommand(Table entity) => Table = entity;

    public UpdateTableCommand() { }
}