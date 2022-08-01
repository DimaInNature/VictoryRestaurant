namespace Victory.Microservices.SMTP.Domain.Queries.MailSubscribers;

public sealed record class GetMailSubscriberListQuery : IRequest<IEnumerable<MailSubscriberEntity>> { }