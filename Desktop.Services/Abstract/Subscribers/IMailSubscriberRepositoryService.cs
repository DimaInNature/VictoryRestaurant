namespace Desktop.Services.Abstract.Subscribers;

public interface IMailSubscriberRepositoryService
{
    Task<List<MailSubscriber>> GetMailSubscriberListAsync();
    Task<MailSubscriber?> GetMailSubscriberAsync(int mailSubscriberId);
    Task DeleteAsync(int mailSubscriberId);
}