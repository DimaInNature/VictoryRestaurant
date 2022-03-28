namespace Desktop.Data.Repositories.Abstract;

public interface IContactMessageRepository : IDisposable
{
    Task<List<ContactMessage>> GetContactMessageListAsync();
    Task<ContactMessage> GetContactMessageAsync(int contactMessageId);
    Task DeleteAsync(int bookingId);
}