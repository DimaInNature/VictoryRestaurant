namespace Victory.Application.Features.Subscribers;

public sealed record class GetMailSubscribersListQuery : IRequest<List<MailSubscriber>?> { }