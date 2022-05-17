namespace Victory.Application.Api.Features.Subscribers;

public sealed record class GetMailSubscriberListQuery : IRequest<List<MailSubscriberEntity>?> { }