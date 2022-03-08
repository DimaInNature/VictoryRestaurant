namespace API.Services.Abstract.Repositories;

public interface IMailSubscriberRepositoryService
{
    Task<List<MailSubscriberEntity>> GetMailSubscribersAsync();
    Task<MailSubscriberEntity> GetMailSubscriberAsync(int mailSubscriberId);
    Task InsertMailSubscriberAsync(MailSubscriberEntity mailSubscriber);
    Task UpdateMailSubscriberAsync(MailSubscriberEntity mailSubscriber);
    Task DeleteMailSubscriberAsync(int mailSubscriberId);
    Task SaveAsync();
}