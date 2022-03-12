namespace API.Services.Subscribers;

public class MailSubscriberFacadeService : IMailSubscriberFacadeService
{
    private readonly IMailSubscriberRepositoryService _repository;
    private readonly ICacheService<MailSubscriberEntity> _cache;

    public MailSubscriberFacadeService(IMailSubscriberRepositoryService repository,
        ICacheService<MailSubscriberEntity> cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<List<MailSubscriberEntity>> GetMailSubscribersAsync() =>
        await _repository.GetMailSubscribersAsync();

    public async Task<MailSubscriberEntity> GetMailSubscriberAsync(int mailSubscriberId)
    {
        if (_cache.TryGet(mailSubscriberId, out var mailSubscriber))
            return mailSubscriber;
        else
        {
            mailSubscriber = await _repository.GetMailSubscriberAsync(mailSubscriberId);

            return _cache.Set(key: mailSubscriberId, value: mailSubscriber);
        }
    }

    public async Task InsertMailSubscriberAsync(MailSubscriberEntity mailSubscriber)
    {
        await _repository.InsertMailSubscriberAsync(mailSubscriber);

        _cache.Set(key: mailSubscriber.Id, value: mailSubscriber);
    }

    public async Task UpdateMailSubscriberAsync(MailSubscriberEntity mailSubscriber)
    {
        await _repository.UpdateMailSubscriberAsync(mailSubscriber);

        _cache.Set(key: mailSubscriber.Id, value: mailSubscriber);
    }

    public async Task DeleteMailSubscriberAsync(int mailSubscriberId)
    {
        await _repository.DeleteMailSubscriberAsync(mailSubscriberId);

        if (_cache.TryGet(key: mailSubscriberId, out _))
            _cache.Remove(key: mailSubscriberId);
    }

    public async Task<int> SaveAsync() => await _repository.SaveAsync();
}