namespace Victory.Application.Web.Data.MailSubscribers;

public class MailSubscriberFacadeService : IMailSubscriberFacadeService
{
    private readonly MailSubscriberRepositoryServiceLoggerDecorator _repository;

    private readonly ICacheService<MailSubscriber> _cache;

    public MailSubscriberFacadeService(ICacheService<MailSubscriber> cache,
        MailSubscriberRepositoryServiceLoggerDecorator repository) =>
        (_repository, _cache) = (repository, cache);

    public Task<List<MailSubscriber>> GetMailSubscriberListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<MailSubscriber?> GetMailSubscriberAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(MailSubscriber entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}