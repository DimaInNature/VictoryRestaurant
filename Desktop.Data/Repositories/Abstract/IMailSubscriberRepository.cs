namespace Desktop.Data.Repositories.Abstract;

public interface IMailSubscriberRepository : IDisposable
{
    Task<List<MailSubscriber>> GetMailSubscriberListAsync();
    Task<MailSubscriber> GetMailSubscriberAsync(int mailSubscriberId);
    Task DeleteAsync(int mailSubscriberId);
}