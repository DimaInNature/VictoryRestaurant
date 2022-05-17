namespace Victory.Application.General.Client.Features.Subscribers;

public sealed record class DeleteMailSubscriberCommand : IRequest
{
    public int Id { get; }

    public DeleteMailSubscriberCommand(int id) => Id = id;

    public DeleteMailSubscriberCommand() { }
}