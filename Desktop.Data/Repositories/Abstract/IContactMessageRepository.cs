namespace Desktop.Data.Repositories.Abstract;

public interface IContactMessageRepository : IDisposable
{
    Task<List<ContactMessage>> GetContactMessagesAsync();
    Task<ContactMessage> GetContactMessageAsync(int contactMessageId);
    Task DeleteContactMessageAsync(int bookingId);
}