namespace Desktop.Data.Repositories.Abstract;

public interface IMailSubscriberRepository : IDisposable
{
    Task<List<MailSubscriber>> GetMailSubscribersAsync();
    Task<MailSubscriber> GetMailSubscriberAsync(int mailSubscriberId);
    Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber);
    Task UpdateMailSubscriberAsync(MailSubscriber mailSubscriber);
    Task DeleteMailSubscriberAsync(int mailSubscriberId);
}