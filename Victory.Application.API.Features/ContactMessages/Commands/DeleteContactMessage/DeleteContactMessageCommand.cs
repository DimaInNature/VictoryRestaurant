namespace Victory.Application.API.Features.ContactMessages;

public sealed record class DeleteContactMessageCommand : IRequest
{
    public int Id { get; }

    public DeleteContactMessageCommand(int id) => Id = id;

    public DeleteContactMessageCommand() { }
}