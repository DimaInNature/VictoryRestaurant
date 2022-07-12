namespace Victory.Domain.Interfaces.API.Data.MailSubscribers;

public interface IMailSubscriberRepositoryService
{
    Task<List<MailSubscriberEntity>?> GetMailSubscriberListAsync();
    Task<MailSubscriberEntity?> GetMailSubscriberAsync(int mailSubscriberId);
    Task CreateAsync(MailSubscriberEntity entity);
    Task UpdateAsync(MailSubscriberEntity entity);
    Task DeleteAsync(int mailSubscriberId);
}