namespace Web.Services.Messages;

public class ContactMessageRepositoryService : IContactMessageRepositoryService
{
    private readonly IContactMessageRepository _repository;

    public ContactMessageRepositoryService(IContactMessageRepository repository)
    {
        _repository = repository;
    }

    public async Task InsertContactMessageAsync(ContactMessage contactMessage) =>
        await _repository.InsertContactMessageAsync(contactMessage.ToEntity());
}