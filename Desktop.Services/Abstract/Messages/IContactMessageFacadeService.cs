namespace Desktop.Services.Abstract.Messages;

public interface IContactMessageFacadeService
{
    Task<List<ContactMessage>> GetContactMessageListAsync();
    Task<ContactMessage?> GetContactMessageAsync(int contactMessageId);
    Task DeleteAsync(int bookingId);
}