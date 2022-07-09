namespace Victory.Domain.Interfaces.Clients.Data.ContactMessages;

public interface IContactMessageFacadeService
{
    Task<List<ContactMessage>> GetContactMessageListAsync(string token);
    Task<ContactMessage?> GetContactMessageAsync(int id, string token);
    Task CreateAsync(ContactMessage entity);
    Task DeleteAsync(int id, string token);
}