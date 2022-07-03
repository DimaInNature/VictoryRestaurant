namespace Victory.Application.CQRS.API.ContactMessages;

public sealed record class DeleteContactMessageCommand : IRequest
{
    public int Id { get; }

    public DeleteContactMessageCommand(int id) => Id = id;

    public DeleteContactMessageCommand() { }
}