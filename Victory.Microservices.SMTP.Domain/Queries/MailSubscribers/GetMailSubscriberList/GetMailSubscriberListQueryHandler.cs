namespace Victory.Microservices.SMTP.Domain.Queries.MailSubscribers;

public sealed record class GetMailSubscriberListQueryHandler
    : IRequestHandler<GetMailSubscriberListQuery, IEnumerable<MailSubscriberEntity>>
{
    private readonly IGenericRepository<MailSubscriberEntity> _repository;

    public GetMailSubscriberListQueryHandler(
        IGenericRepository<MailSubscriberEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<MailSubscriberEntity>> Handle(
        GetMailSubscriberListQuery request,
        CancellationToken token) =>
        _repository.GetAll() ?? new List<MailSubscriberEntity>();
}