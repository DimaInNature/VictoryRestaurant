namespace Victory.Application.General.Client.Features.Tables;

public sealed record class CreateTableCommand : IRequest
{
    public Table? Table { get; }

    public CreateTableCommand(Table entity) => Table = entity;

    public CreateTableCommand() { }
}