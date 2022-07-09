namespace Victory.Application.Desktop.Data.ContactMessages;

public sealed class ContactMessageFacadeService : IContactMessageFacadeService
{
    private readonly IContactMessageRepositoryService _repository;

    public ContactMessageFacadeService(IContactMessageRepositoryService repository) =>
        _repository = repository;

    public async Task<List<ContactMessage>> GetContactMessageListAsync(string token) =>
        await _repository.GetContactMessageListAsync(token);

    public async Task<ContactMessage?> GetContactMessageAsync(int id, string token) =>
        await _repository.GetContactMessageAsync(id, token);

    public async Task CreateAsync(ContactMessage entity) =>
       await _repository.CreateAsync(entity);

    public async Task DeleteAsync(int id, string token) =>
        await _repository.DeleteAsync(id, token);
}