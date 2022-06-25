namespace Victory.Application.API.Features.Tables;

public sealed record class DeleteTableCommand : IRequest
{
    public int Id { get; }

    public DeleteTableCommand(int id) => Id = id;

    public DeleteTableCommand() { }
}