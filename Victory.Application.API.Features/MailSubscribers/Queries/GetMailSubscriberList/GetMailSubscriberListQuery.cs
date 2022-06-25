namespace Victory.Application.API.Features.MailSubscribers;

public sealed record class GetMailSubscriberListQuery : IRequest<List<MailSubscriberEntity>?> { }