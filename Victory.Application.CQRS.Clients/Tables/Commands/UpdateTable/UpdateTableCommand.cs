namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class UpdateTableCommand : IRequest
{
    public Table? Table { get; }

    public UpdateTableCommand(Table entity) => Table = entity;

    public UpdateTableCommand() { }
}