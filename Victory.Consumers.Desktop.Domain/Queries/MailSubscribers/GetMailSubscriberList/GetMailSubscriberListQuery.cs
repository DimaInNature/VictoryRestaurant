namespace Victory.Consumers.Desktop.Domain.Queries.MailSubscribers;

public sealed record class GetMailSubscriberListQuery
    : BaseAnonymousFeature, IRequest<List<MailSubscriber>?>
{ }