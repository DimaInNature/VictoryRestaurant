namespace Victory.Application.CQRS.API.MailSubscribers;

public sealed record class GetMailSubscriberListQuery : IRequest<List<MailSubscriberEntity>?> { }