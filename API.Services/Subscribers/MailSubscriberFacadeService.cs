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

    public async Task<List<MailSubscriberEntity>> GetMailSubscriberListAsync() =>
        await _repository.GetMailSubscriberListAsync();

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

    public async Task CreateAsync(MailSubscriberEntity mailSubscriber)
    {
        await _repository.CreateAsync(mailSubscriber);

        _cache.Set(key: mailSubscriber.Id, value: mailSubscriber);
    }

    public async Task UpdateAsync(MailSubscriberEntity mailSubscriber)
    {
        await _repository.UpdateAsync(mailSubscriber);

        _cache.Set(key: mailSubscriber.Id, value: mailSubscriber);
    }

    public async Task DeleteAsync(int mailSubscriberId)
    {
        await _repository.DeleteAsync(mailSubscriberId);

        if (_cache.TryGet(key: mailSubscriberId, out _))
            _cache.Remove(key: mailSubscriberId);
    }
}