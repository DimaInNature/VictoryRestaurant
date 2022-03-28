namespace Desktop.Services.Messages;

public sealed class ContactMessageFacadeService : IContactMessageFacadeService
{
    private readonly IContactMessageRepositoryService _repository;

    public ContactMessageFacadeService(IContactMessageRepositoryService repository)
    {
        _repository = repository;
    }

    public async Task<List<ContactMessage>> GetContactMessageListAsync() =>
        await _repository.GetContactMessageListAsync();

    public async Task<ContactMessage?> GetContactMessageAsync(int contactMessageId) =>
        await _repository.GetContactMessageAsync(contactMessageId);

    public async Task DeleteAsync(int bookingId) =>
        await _repository.DeleteAsync(bookingId);
}