namespace Victory.Consumers.Web.Application.Services.ContactMessages;

public class ContactMessageCacheService : IContactMessageService
{
    private const string NameForCaching = "ContactMessage";

    private readonly IContactMessageService _repository;

    private readonly ISyncCacheService<ContactMessage> _cache;

    public ContactMessageCacheService(
        ISyncCacheService<ContactMessage> cache,
        IContactMessageService repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task CreateAsync(ContactMessage entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }
}