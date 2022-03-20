namespace Web.Services.Subscribers;

public class MailSubscriberRepositoryService : IMailSubscriberRepositoryService
{
    private readonly IMailSubscriberRepository _repository;
    private readonly IMapper _mapper;

    public MailSubscriberRepositoryService(IMapper mapper,
        IMailSubscriberRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber) =>
        await _repository.InsertMailSubscriberAsync(
            mailSubscriber: _mapper.Map<MailSubscriberEntity>(source: mailSubscriber));
}
