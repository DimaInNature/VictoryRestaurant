namespace Victory.Application.Services.Interfaces;

public interface IMailSubscriberRepositoryService
{
    Task<List<MailSubscriberEntity>?> GetMailSubscriberListAsync();
    Task<MailSubscriberEntity?> GetMailSubscriberAsync(int mailSubscriberId);
    Task CreateAsync(MailSubscriberEntity mailSubscriber);
    Task UpdateAsync(MailSubscriberEntity mailSubscriber);
    Task DeleteAsync(int mailSubscriberId);
}