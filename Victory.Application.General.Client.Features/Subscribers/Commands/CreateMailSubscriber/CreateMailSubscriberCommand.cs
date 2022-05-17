namespace Victory.Application.General.Client.Features.Subscribers;

public sealed record class CreateMailSubscriberCommand : IRequest
{
    public MailSubscriber? MailSubscriber { get; }

    public CreateMailSubscriberCommand(MailSubscriber entity) => MailSubscriber = entity;

    public CreateMailSubscriberCommand() { }
}