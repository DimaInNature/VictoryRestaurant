namespace Victory.Application.API.Interfaces.Data.MailSubscribers;

public interface IMailSubscriberRepositoryService
{
    Task<List<MailSubscriberEntity>?> GetMailSubscriberListAsync();
    Task<MailSubscriberEntity?> GetMailSubscriberAsync(int mailSubscriberId);
    Task CreateAsync(MailSubscriberEntity mailSubscriber);
    Task UpdateAsync(MailSubscriberEntity mailSubscriber);
    Task DeleteAsync(int mailSubscriberId);
}