namespace Desktop.Services.Messages;

public sealed class ContactMessageRepositoryService : IContactMessageRepositoryService
{
    private readonly IContactMessageRepository _repository;

    public ContactMessageRepositoryService(IContactMessageRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ContactMessage>> GetContactMessagesAsync() =>
        await _repository.GetContactMessagesAsync() ?? new();

    public async Task<ContactMessage?> GetContactMessageAsync(int contactMessageId)
    {
        if (contactMessageId < 1) return null;

        return await _repository.GetContactMessageAsync(contactMessageId);
    }

    public async Task DeleteContactMessageAsync(int contactMessageId)
    {
        if (contactMessageId < 1) return;

        await _repository.DeleteContactMessageAsync(contactMessageId);
    }
}