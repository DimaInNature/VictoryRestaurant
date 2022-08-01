namespace Victory.Microservices.SMTP.Domain.Queries.MailSubscribers;

public sealed record class GetMailSubscriberListByPredicateQueryHandler
    : IRequestHandler<GetMailSubscriberListByPredicateQuery, IEnumerable<MailSubscriberEntity>>
{
    private readonly IGenericRepository<MailSubscriberEntity> _repository;

    public GetMailSubscriberListByPredicateQueryHandler(
        IGenericRepository<MailSubscriberEntity> repository) => _repository = repository;

    public async Task<IEnumerable<MailSubscriberEntity>> Handle(
        GetMailSubscriberListByPredicateQuery request,
        CancellationToken token) =>
        request.Predicate is null
        ? new List<MailSubscriberEntity>()
        : _repository.GetAll(
            user => request.Predicate(user)) ?? new List<MailSubscriberEntity>();
}