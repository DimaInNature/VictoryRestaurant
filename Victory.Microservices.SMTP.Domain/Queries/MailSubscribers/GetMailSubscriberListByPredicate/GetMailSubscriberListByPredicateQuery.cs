namespace Victory.Microservices.SMTP.Domain.Queries.MailSubscribers;

public sealed record class GetMailSubscriberListByPredicateQuery
    : IRequest<IEnumerable<MailSubscriberEntity>>
{
    public Func<MailSubscriberEntity, bool>? Predicate { get; }

    public GetMailSubscriberListByPredicateQuery(
        Func<MailSubscriberEntity, bool> predicate) =>
        Predicate = predicate;

    public GetMailSubscriberListByPredicateQuery() { }
}