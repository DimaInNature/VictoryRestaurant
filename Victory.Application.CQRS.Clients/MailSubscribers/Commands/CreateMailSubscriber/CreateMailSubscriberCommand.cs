namespace Victory.Application.CQRS.Clients.MailSubscribers;

public sealed record class CreateMailSubscriberCommand : IRequest
{
    public MailSubscriber? MailSubscriber { get; }

    public CreateMailSubscriberCommand(MailSubscriber entity) => MailSubscriber = entity;

    public CreateMailSubscriberCommand() { }
}