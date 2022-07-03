namespace Victory.Application.CQRS.API.MailSubscribers;

public sealed record class UpdateMailSubscriberCommand : IRequest
{
    public MailSubscriberEntity? MailSubscriber { get; }

    public UpdateMailSubscriberCommand(MailSubscriberEntity mailSubscriber) => MailSubscriber = mailSubscriber;

    public UpdateMailSubscriberCommand() { }
}