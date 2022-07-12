namespace Victory.Domain.Consumers.Decorators.MailSubscribers;

public class MailSubscriberRepositoryCacheService : IMailSubscriberRepositoryService
{
    private const string NameForCaching = "MailSubscriber";

    private readonly IMailSubscriberRepositoryService _repository;

    private readonly ISyncCacheService<MailSubscriber> _cache;

    public MailSubscriberRepositoryCacheService(
        ISyncCacheService<MailSubscriber> cache,
        IMailSubscriberRepositoryService repository) =>
        (_repository, _cache) = (repository, cache);

    public Task<List<MailSubscriber>> GetMailSubscriberListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<MailSubscriber?> GetMailSubscriberAsync(int id, string token)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(MailSubscriber entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    public Task DeleteAsync(int id, string token)
    {
        throw new NotImplementedException();
    }
}