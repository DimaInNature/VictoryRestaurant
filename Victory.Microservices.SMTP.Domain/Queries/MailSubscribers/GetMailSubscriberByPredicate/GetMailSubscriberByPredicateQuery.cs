namespace Victory.Microservices.SMTP.Domain.Queries.MailSubscribers;

public sealed record class GetMailSubscriberByPredicateQuery : IRequest<MailSubscriberEntity?>
{
    public Func<MailSubscriberEntity, bool>? Predicate { get; }

    public GetMailSubscriberByPredicateQuery(
        Func<MailSubscriberEntity, bool> predicate) =>
        Predicate = predicate;

    public GetMailSubscriberByPredicateQuery() { }
}