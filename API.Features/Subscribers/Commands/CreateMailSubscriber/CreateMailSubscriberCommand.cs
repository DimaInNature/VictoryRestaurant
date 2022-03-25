namespace API.Features.Subscribers.Commands;

public sealed record class CreateMailSubscriberCommand : IRequest
{
    public MailSubscriberEntity? MailSubscriber { get; }

    public CreateMailSubscriberCommand(MailSubscriberEntity mailSubscriber!!) => MailSubscriber = mailSubscriber;

    public CreateMailSubscriberCommand() { }
}