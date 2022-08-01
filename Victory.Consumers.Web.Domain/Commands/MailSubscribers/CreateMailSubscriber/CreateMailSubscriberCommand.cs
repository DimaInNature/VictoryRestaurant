namespace Victory.Consumers.Web.Domain.Commands.MailSubscribers;

public sealed record class CreateMailSubscriberCommand
    : BaseAnonymousFeature, IRequest
{
    public MailSubscriber? MailSubscriber { get; }

    public CreateMailSubscriberCommand(MailSubscriber entity) => MailSubscriber = entity;

    public CreateMailSubscriberCommand() { }
}