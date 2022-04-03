namespace Victory.Application.Services;

public class ContactMessageFacadeService : IContactMessageFacadeService
{
    private readonly IContactMessageRepositoryService _repository;
    private readonly ICacheService<ContactMessageEntity> _cache;

    public ContactMessageFacadeService(IContactMessageRepositoryService repository,
        ICacheService<ContactMessageEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<ContactMessageEntity>> GetContactMessageListAsync() =>
        await _repository.GetContactMessageListAsync() ?? new();

    public async Task<ContactMessageEntity?> GetContactMessageAsync(int id)
    {
        if (_cache.TryGet(id, out var entity)) return entity;

        entity = await _repository.GetContactMessageAsync(id);

        return entity is null ? null : _cache.Set(key: id, value: entity);
    }

    public async Task CreateAsync(ContactMessageEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(ContactMessageEntity entity)
    {
        if (entity is null) return;

        await _repository.UpdateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        if (_cache.TryGet(key: id, out _)) _cache.Remove(key: id);
    }
}