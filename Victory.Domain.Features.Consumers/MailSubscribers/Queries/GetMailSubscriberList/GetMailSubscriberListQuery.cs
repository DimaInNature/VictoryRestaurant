namespace Victory.Domain.Features.Consumers.MailSubscribers;

public sealed record class GetMailSubscriberListQuery
	: BaseAnonymousFeature, IRequest<List<MailSubscriber>?>
{

}