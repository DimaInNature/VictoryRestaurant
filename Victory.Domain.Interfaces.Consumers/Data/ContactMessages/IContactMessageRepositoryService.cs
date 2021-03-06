namespace Victory.Domain.Interfaces.Consumers.Data.ContactMessages;

public interface IContactMessageRepositoryService
{
    Task<List<ContactMessage>> GetContactMessageListAsync(string token);
    Task<ContactMessage?> GetContactMessageAsync(int id, string token);
    Task CreateAsync(ContactMessage entity);
    Task DeleteAsync(int id, string token);
}