namespace Victory.Application.General.Client.Interfaces.Data.ContactMessages;

public interface IContactMessageRepositoryService
{
    Task<List<ContactMessage>> GetContactMessageListAsync();
    Task<ContactMessage?> GetContactMessageAsync(int id);
    Task DeleteAsync(int id);
}