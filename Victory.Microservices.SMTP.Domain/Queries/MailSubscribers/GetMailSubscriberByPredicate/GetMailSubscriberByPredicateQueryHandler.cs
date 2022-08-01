namespace Victory.Microservices.SMTP.Domain.Queries.MailSubscribers;

public sealed record class GetMailSubscriberByPredicateQueryHandler
    : IRequestHandler<GetMailSubscriberByPredicateQuery, MailSubscriberEntity?>
{
    private readonly IGenericRepository<MailSubscriberEntity> _repository;

    public GetMailSubscriberByPredicateQueryHandler(
        IGenericRepository<MailSubscriberEntity> repository) =>
        _repository = repository;

    public async Task<MailSubscriberEntity?> Handle(
        GetMailSubscriberByPredicateQuery request,
        CancellationToken token) =>
        request.Predicate is null
        ? null
        : _repository.GetFirstOrDefault(
            predicate: user => request.Predicate(user));

}