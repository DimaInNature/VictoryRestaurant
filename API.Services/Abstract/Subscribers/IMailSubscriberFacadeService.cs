namespace API.Services.Abstract.Subscribers;

public interface IMailSubscriberFacadeService
{
    Task<List<MailSubscriberEntity>> GetMailSubscribersAsync();
    Task<MailSubscriberEntity> GetMailSubscriberAsync(int mailSubscriberId);
    Task InsertMailSubscriberAsync(MailSubscriberEntity mailSubscriber);
    Task UpdateMailSubscriberAsync(MailSubscriberEntity mailSubscriber);
    Task DeleteMailSubscriberAsync(int mailSubscriberId);
    Task<int> SaveAsync();
}