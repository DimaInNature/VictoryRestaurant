namespace API.Services.Abstract.Messages;

public interface IContactMessageFacadeService
{
    Task<List<ContactMessageEntity>> GetContactMessageListAsync();
    Task<ContactMessageEntity> GetContactMessageAsync(int contactMessageId);
    Task CreateAsync(ContactMessageEntity contactMessage);
    Task UpdateAsync(ContactMessageEntity contactMessage);
    Task DeleteAsync(int bookingId);
}