namespace Victory.Application.CQRS.Clients.MailSubscribers;

public sealed record class GetMailSubscriberListQuery
	: BaseAnonymousFeature, IRequest<List<MailSubscriber>?>
{

}