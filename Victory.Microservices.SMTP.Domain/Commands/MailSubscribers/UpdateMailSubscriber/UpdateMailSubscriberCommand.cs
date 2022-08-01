namespace Victory.Microservices.SMTP.Domain.Commands.MailSubscribers;

public sealed record class UpdateMailSubscriberCommand : IRequest
{
    public MailSubscriberEntity? MailSubscriber { get; }

    public UpdateMailSubscriberCommand(MailSubscriberEntity entity) => MailSubscriber = entity;

    public UpdateMailSubscriberCommand() { }
}