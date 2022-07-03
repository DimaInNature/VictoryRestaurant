namespace Victory.Application.Desktop.Data.ContactMessages;

public sealed class ContactMessageFacadeService : IContactMessageFacadeService
{
    private readonly IContactMessageRepositoryService _repository;

    public ContactMessageFacadeService(IContactMessageRepositoryService repository) =>
        _repository = repository;

    public async Task<List<ContactMessage>> GetContactMessageListAsync() =>
        await _repository.GetContactMessageListAsync();

    public async Task<ContactMessage?> GetContactMessageAsync(int id) =>
        await _repository.GetContactMessageAsync(id);

    public async Task CreateAsync(ContactMessage entity) =>
       await _repository.CreateAsync(entity);

    public async Task DeleteAsync(int id) =>
        await _repository.DeleteAsync(id);
}