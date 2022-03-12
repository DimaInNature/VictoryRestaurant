namespace Web.Services.Subscribers;

public class MailSubscriberFacadeService : IMailSubscriberFacadeService
{
    private readonly MailSubscriberRepositoryServiceLoggerDecorator _repository;
    private readonly ICacheService<MailSubscriber> _cache;

    public MailSubscriberFacadeService(ICacheService<MailSubscriber> cache,
        MailSubscriberRepositoryServiceLoggerDecorator repository)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber)
    {
        await _repository.InsertMailSubscriberAsync(mailSubscriber);

        _cache.Set(key: mailSubscriber.Id, value: mailSubscriber);
    }
}