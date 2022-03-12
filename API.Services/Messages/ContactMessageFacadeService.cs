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

    public async Task<List<ContactMessageEntity>> GetContactMessagesAsync() =>
        await _repository.GetContactMessagesAsync();

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

    public async Task InsertContactMessageAsync(ContactMessageEntity contactMessage)
    {
        await _repository.InsertContactMessageAsync(contactMessage);

        _cache.Set(key: contactMessage.Id, value: contactMessage);
    }

    public async Task UpdateContactMessageAsync(ContactMessageEntity contactMessage)
    {
        await _repository.UpdateContactMessageAsync(contactMessage);

        _cache.Set(key: contactMessage.Id, value: contactMessage);
    }

    public async Task DeleteContactMessageAsync(int contactMessageId)
    {
        await _repository.DeleteContactMessageAsync(contactMessageId);

        if (_cache.TryGet(key: contactMessageId, out _))
            _cache.Remove(key: contactMessageId);
    }

    public async Task<int> SaveAsync() => await _repository.SaveAsync();
}