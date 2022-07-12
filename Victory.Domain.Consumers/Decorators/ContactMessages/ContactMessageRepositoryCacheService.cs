namespace Victory.Domain.Consumers.Decorators.ContactMessages;

public class ContactMessageRepositoryCacheService : IContactMessageRepositoryService
{
    private const string NameForCaching = "ContactMessage";

    private readonly IContactMessageRepositoryService _repository;

    private readonly ISyncCacheService<ContactMessage> _cache;

    public ContactMessageRepositoryCacheService(
        ISyncCacheService<ContactMessage> cache,
        IContactMessageRepositoryService repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<ContactMessage>> GetContactMessageListAsync(string token) =>
        await _repository.GetContactMessageListAsync(token) ?? new();

    public async Task<ContactMessage?> GetContactMessageAsync(int id, string token)
    {
        ContactMessage? cached = _cache.Get(key: $"{NameForCaching}_{id}");

        if (cached is not null) return cached;

        ContactMessage? entityFromDb = await _repository.GetContactMessageAsync(id, token);

        if (entityFromDb is null) return null;

        _cache.Set(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task CreateAsync(ContactMessage entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    public async Task DeleteAsync(int id, string token)
    {
        await _repository.DeleteAsync(id, token);

        _cache.Remove(key: $"{NameForCaching}_{id}");
    }
}