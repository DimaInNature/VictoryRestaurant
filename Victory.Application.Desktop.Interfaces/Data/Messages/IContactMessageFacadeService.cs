namespace Victory.Application.Desktop.Interfaces.Data.Messages;

public interface IContactMessageFacadeService
{
    Task<List<ContactMessage>> GetContactMessageListAsync();
    Task<ContactMessage?> GetContactMessageAsync(int id);
    Task DeleteAsync(int id);
}