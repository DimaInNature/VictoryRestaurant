namespace Victory.Application.CQRS.Clients.MailSubscribers;

public sealed record class GetMailSubscriberListQuery : IRequest<List<MailSubscriber>?> { }