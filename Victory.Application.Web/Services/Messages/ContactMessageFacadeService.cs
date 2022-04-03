namespace Victory.Application.Web.Services;

public class ContactMessageFacadeService : IContactMessageFacadeService
{
    private readonly ContactMessageRepositoryServiceLoggerDecorator _repository;
    private readonly ICacheService<ContactMessage> _cache;

    public ContactMessageFacadeService(ICacheService<ContactMessage> cache,
        ContactMessageRepositoryServiceLoggerDecorator repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task CreateAsync(ContactMessage entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }
}