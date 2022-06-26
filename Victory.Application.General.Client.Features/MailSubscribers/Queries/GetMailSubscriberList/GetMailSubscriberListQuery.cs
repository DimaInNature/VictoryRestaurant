namespace Victory.Application.General.Client.Features.MailSubscribers;

public sealed record class GetMailSubscriberListQuery : IRequest<List<MailSubscriber>?> { }