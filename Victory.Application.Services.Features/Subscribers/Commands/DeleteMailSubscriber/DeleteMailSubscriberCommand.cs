namespace Victory.Application.Services.Features.Subscribers;

public sealed record class DeleteMailSubscriberCommand : IRequest
{
    public int Id { get; }

    public DeleteMailSubscriberCommand(int id) => Id = id;

    public DeleteMailSubscriberCommand() { }
}