namespace Desktop.Services.Abstract.Messages;

public interface IContactMessageRepositoryService
{
    Task<List<ContactMessage>> GetContactMessageListAsync();
    Task<ContactMessage?> GetContactMessageAsync(int contactMessageId);
    Task DeleteAsync(int bookingId);
}