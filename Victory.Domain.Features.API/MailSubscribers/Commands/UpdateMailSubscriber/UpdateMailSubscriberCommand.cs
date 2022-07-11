namespace Victory.Domain.Features.API.MailSubscribers;

public sealed record class UpdateMailSubscriberCommand : IRequest
{
    public MailSubscriberEntity? MailSubscriber { get; }

    public UpdateMailSubscriberCommand(MailSubscriberEntity mailSubscriber) =>
        MailSubscriber = mailSubscriber;

    public UpdateMailSubscriberCommand() { }
}