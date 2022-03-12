namespace API.Services.Abstract.Messages;

public interface IContactMessageRepositoryService
{
    Task<List<ContactMessageEntity>> GetContactMessagesAsync();
    Task<ContactMessageEntity> GetContactMessageAsync(int contactMessageId);
    Task InsertContactMessageAsync(ContactMessageEntity contactMessage);
    Task UpdateContactMessageAsync(ContactMessageEntity contactMessage);
    Task DeleteContactMessageAsync(int bookingId);
    Task<int> SaveAsync();
}