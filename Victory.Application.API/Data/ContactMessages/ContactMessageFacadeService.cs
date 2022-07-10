namespace Victory.Application.API.Data.ContactMessages;

public class ContactMessageFacadeService : IContactMessageFacadeService
{
    private const string NameForCaching = "ContactMessage";

    private readonly IContactMessageRepositoryService _repository;

    private readonly ICacheService<ContactMessageEntity> _cache;

    public ContactMessageFacadeService(IContactMessageRepositoryService repository,
        ICacheService<ContactMessageEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<ContactMessageEntity>> GetContactMessageListAsync() =>
        await _repository.GetContactMessageListAsync() ?? new();

    public async Task<ContactMessageEntity?> GetContactMessageAsync(int id)
    {
        ContactMessageEntity? entityFromCache = await _cache.GetAsync(key: $"{NameForCaching}_{id}");

        if (entityFromCache is not null) return entityFromCache;

        ContactMessageEntity? entityFromDb = await _repository.GetContactMessageAsync(id);

        if (entityFromDb is null) return null;

        await _cache.SetAsync(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task CreateAsync(ContactMessageEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    public async Task UpdateAsync(ContactMessageEntity entity)
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