namespace API.Services.ContactMessages;

public class ContactMessageRepositoryService : IContactMessageRepositoryService
{
    private readonly IContactMessageRepository _repository;

    public ContactMessageRepositoryService(IContactMessageRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ContactMessageEntity>> GetContactMessagesAsync() =>
        await _repository.GetContactMessagesAsync();

    public async Task<ContactMessageEntity> GetContactMessageAsync(int contactMessageId) =>
        await _repository.GetContactMessageAsync(contactMessageId);

    public async Task InsertContactMessageAsync(ContactMessageEntity contactMessage) =>
        await _repository.InsertContactMessageAsync(contactMessage);

    public async Task UpdateContactMessageAsync(ContactMessageEntity contactMessage) =>
        await _repository.UpdateContactMessageAsync(contactMessage);

    public async Task DeleteContactMessageAsync(int bookingId) =>
        await _repository.DeleteContactMessageAsync(bookingId);

    public async Task<int> SaveAsync() => await _repository.SaveAsync();
}