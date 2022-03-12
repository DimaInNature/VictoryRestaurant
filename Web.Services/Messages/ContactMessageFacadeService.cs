namespace Web.Services.Messages;

public class ContactMessageFacadeService : IContactMessageFacadeService
{
    private readonly ContactMessageRepositoryServiceLoggerDecorator _repository;
    private readonly ICacheService<ContactMessage> _cache;

    public ContactMessageFacadeService(ICacheService<ContactMessage> cache,
        ContactMessageRepositoryServiceLoggerDecorator repositoryService)
    {
        _repository = repositoryService;
        _cache = cache;
    }

    public async Task InsertContactMessageAsync(ContactMessage contactMessage)
    {
        await _repository.InsertContactMessageAsync(contactMessage);

        _cache.Set(key: contactMessage.Id, value: contactMessage);
    }
}