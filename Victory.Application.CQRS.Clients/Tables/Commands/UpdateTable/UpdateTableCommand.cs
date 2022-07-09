namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class UpdateTableCommand
    : BaseAnonymousFeature, IRequest
{
    public Table? Table { get; }

    public UpdateTableCommand(Table entity) => Table = entity;

    public UpdateTableCommand() { }
}