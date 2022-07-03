namespace Victory.Domain.Interfaces.Clients.Data.ContactMessages;

public interface IContactMessageRepositoryService
{
    Task<List<ContactMessage>> GetContactMessageListAsync();
    Task<ContactMessage?> GetContactMessageAsync(int id);
    Task CreateAsync(ContactMessage entity);
    Task DeleteAsync(int id);
}