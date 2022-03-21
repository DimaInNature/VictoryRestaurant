namespace Desktop.Services.Abstract.Messages;

public interface IContactMessageRepositoryService
{
    Task<List<ContactMessage>> GetContactMessagesAsync();
    Task<ContactMessage?> GetContactMessageAsync(int contactMessageId);
    Task DeleteContactMessageAsync(int bookingId);
}