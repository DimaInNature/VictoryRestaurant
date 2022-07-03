namespace Victory.Application.CQRS.Clients.Tables;

public sealed record class DeleteTableCommand : IRequest
{
    public int Id { get; }

    public DeleteTableCommand(int id) => Id = id;

    public DeleteTableCommand() { }
}