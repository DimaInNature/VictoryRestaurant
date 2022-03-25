namespace API.Services.ContactMessages;

public class ContactMessageFacadeService : IContactMessageFacadeService
{
    private readonly IContactMessageRepositoryService _repository;
    private readonly ICacheService<ContactMessageEntity> _cache;

    public ContactMessageFacadeService(IContactMessageRepositoryService repository,
        ICacheService<ContactMessageEntity> cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<List<ContactMessageEntity>> GetContactMessageListAsync() =>
        await _repository.GetContactMessageListAsync();

    public async Task<ContactMessageEntity> GetContactMessageAsync(int contactMessageId)
    {
        if (_cache.TryGet(contactMessageId, out var contactMessage))
            return contactMessage;
        else
        {
            contactMessage = await _repository.GetContactMessageAsync(contactMessageId);

            return _cache.Set(key: contactMessageId, value: contactMessage);
        }
    }

    public async Task CreateAsync(ContactMessageEntity contactMessage)
    {
        await _repository.CreateAsync(contactMessage);

        _cache.Set(key: contactMessage.Id, value: contactMessage);
    }

    public async Task UpdateAsync(ContactMessageEntity contactMessage)
    {
        await _repository.UpdateAsync(contactMessage);

        _cache.Set(key: contactMessage.Id, value: contactMessage);
    }

    public async Task DeleteAsync(int contactMessageId)
    {
        await _repository.DeleteAsync(contactMessageId);

        if (_cache.TryGet(key: contactMessageId, out _))
            _cache.Remove(key: contactMessageId);
    }
}