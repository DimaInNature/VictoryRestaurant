namespace Desktop.Services.Messages;

public sealed class ContactMessageRepositoryService : IContactMessageRepositoryService
{
    private readonly IContactMessageRepository _repository;

    public ContactMessageRepositoryService(IContactMessageRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ContactMessage>> GetContactMessageListAsync() =>
        await _repository.GetContactMessageListAsync() ?? new();

    public async Task<ContactMessage?> GetContactMessageAsync(int contactMessageId)
    {
        if (contactMessageId < 1) return null;

        return await _repository.GetContactMessageAsync(contactMessageId);
    }

    public async Task DeleteAsync(int contactMessageId)
    {
        if (contactMessageId < 1) return;

        await _repository.DeleteAsync(contactMessageId);
    }
}