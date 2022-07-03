namespace Victory.Application.CQRS.API.Tables;

public sealed record class DeleteTableCommand : IRequest
{
    public int Id { get; }

    public DeleteTableCommand(int id) => Id = id;

    public DeleteTableCommand() { }
}