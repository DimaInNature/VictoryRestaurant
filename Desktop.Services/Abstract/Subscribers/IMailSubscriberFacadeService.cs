namespace Desktop.Services.Abstract.Subscribers;

public interface IMailSubscriberFacadeService
{
    Task<List<MailSubscriber>> GetMailSubscribersAsync();
    Task<MailSubscriber?> GetMailSubscriberAsync(int mailSubscriberId);
    Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber);
    Task UpdateMailSubscriberAsync(MailSubscriber mailSubscriber);
    Task DeleteMailSubscriberAsync(int mailSubscriberId);
}