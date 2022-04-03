namespace Victory.Application.Desktop.Interfaces;

public interface IContactMessageRepositoryService
{
    Task<List<ContactMessage>> GetContactMessageListAsync();
    Task<ContactMessage?> GetContactMessageAsync(int id);
    Task DeleteAsync(int id);
}