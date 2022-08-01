namespace Victory.Microservices.SMTP.Domain.Commands.MailSubscribers;

public sealed record class CreateMailSubscriberCommand : IRequest
{
    public MailSubscriberEntity? MailSubscriber { get; }

    public CreateMailSubscriberCommand(MailSubscriberEntity entity) => MailSubscriber = entity;

    public CreateMailSubscriberCommand() { }
}