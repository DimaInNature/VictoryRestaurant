namespace Victory.Application.Api.Data.Subscribers;

public class MailSubscriberFacadeService : IMailSubscriberFacadeService
{
    private readonly IMailSubscriberRepositoryService _repository;
    private readonly ICacheService<MailSubscriberEntity> _cache;

    public MailSubscriberFacadeService(IMailSubscriberRepositoryService repository,
        ICacheService<MailSubscriberEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<MailSubscriberEntity>> GetMailSubscriberListAsync() =>
        await _repository.GetMailSubscriberListAsync() ?? new();

    public async Task<MailSubscriberEntity?> GetMailSubscriberAsync(int id)
    {
        if (_cache.TryGet(id, out var entity)) return entity;

        entity = await _repository.GetMailSubscriberAsync(id);

        return entity is null ? null : _cache.Set(key: id, value: entity);
    }

    public async Task CreateAsync(MailSubscriberEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(MailSubscriberEntity entity)
    {
        if (entity is null) return;

        await _repository.UpdateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        if (_cache.TryGet(key: id, out _))
            _cache.Remove(key: id);
    }
}