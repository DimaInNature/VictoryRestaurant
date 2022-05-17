namespace Victory.Application.General.Client.Features.Subscribers;

public sealed record class GetMailSubscribersListQuery : IRequest<List<MailSubscriber>?> { }