namespace Victory.Consumers.Desktop.Domain.Interfaces.ContactMessages;

public interface IContactMessageService
{
    Task<List<ContactMessage>> GetContactMessageListAsync(string token);

    Task<ContactMessage?> GetContactMessageAsync(int id, string token);

    Task CreateAsync(ContactMessage entity);

    Task DeleteAsync(int id, string token);
}