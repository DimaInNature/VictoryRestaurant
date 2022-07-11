namespace Victory.Domain.Features.API.MailSubscribers;

public sealed record class GetMailSubscriberListQuery : IRequest<List<MailSubscriberEntity>?> { }