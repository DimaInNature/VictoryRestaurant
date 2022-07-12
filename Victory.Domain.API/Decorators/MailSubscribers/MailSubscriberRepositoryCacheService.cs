namespace Victory.Domain.API.Decorators.MailSubscribers;

public class MailSubscriberRepositoryCacheService : IMailSubscriberRepositoryService
{
    private const string NameForCaching = "MailSubscriber";

    private readonly IMailSubscriberRepositoryService _repository;

    private readonly IAsyncCacheService<MailSubscriberEntity> _cache;

    public MailSubscriberRepositoryCacheService(IMailSubscriberRepositoryService repository,
        IAsyncCacheService<MailSubscriberEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<MailSubscriberEntity>> GetMailSubscriberListAsync() =>
        await _repository.GetMailSubscriberListAsync() ?? new();

    public async Task<MailSubscriberEntity?> GetMailSubscriberAsync(int id)
    {
        MailSubscriberEntity? entityFromCache = await _cache.GetAsync(key: $"{NameForCaching}_{id}");

        if (entityFromCache is not null) return entityFromCache;

        MailSubscriberEntity? entityFromDb = await _repository.GetMailSubscriberAsync(id);

        if (entityFromDb is null) return null;

        await _cache.SetAsync(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task CreateAsync(MailSubscriberEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    public async Task UpdateAsync(MailSubscriberEntity entity)
    {
        if (entity is null) return;

        await _cache.SetAsync(key: $"{NameForCaching}_{entity.Id}", value: entity);

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        await _cache.RemoveAsync(key: $"{NameForCaching}_{id}");
    }
}