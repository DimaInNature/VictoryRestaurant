namespace API.Features.Subscribers.Queries;

public sealed record class GetMailSubscriberListQuery
    : IRequest<List<MailSubscriberEntity>?>
{

}