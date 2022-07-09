namespace Victory.Application.Web.Data.ContactMessages;

public class ContactMessageFacadeService : IContactMessageFacadeService
{
    private readonly ContactMessageRepositoryServiceLoggerDecorator _repository;

    private readonly ICacheService<ContactMessage> _cache;

    public ContactMessageFacadeService(ICacheService<ContactMessage> cache,
        ContactMessageRepositoryServiceLoggerDecorator repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<ContactMessage>> GetContactMessageListAsync(string token) =>
        await _repository.GetContactMessageListAsync(token) ?? new();

    public async Task<ContactMessage?> GetContactMessageAsync(int id, string token)
    {
        if (_cache.TryGet(id, out var entity)) return entity;

        entity = await _repository.GetContactMessageAsync(id, token);

        return entity is null ? null : _cache.Set(key: id, value: entity);
    }

    public async Task CreateAsync(ContactMessage entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id, string token)
    {
        await _repository.DeleteAsync(id, token);

        if (_cache.TryGet(key: id, out _))
            _cache.Remove(key: id);
    }
}