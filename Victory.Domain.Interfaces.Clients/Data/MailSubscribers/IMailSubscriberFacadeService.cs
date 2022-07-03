namespace Victory.Domain.Interfaces.Clients.Data.MailSubscribers;

public interface IMailSubscriberFacadeService
{
    Task<List<MailSubscriber>> GetMailSubscriberListAsync();
    Task<MailSubscriber?> GetMailSubscriberAsync(int id);
    Task CreateAsync(MailSubscriber entity);
    Task DeleteAsync(int id);
}