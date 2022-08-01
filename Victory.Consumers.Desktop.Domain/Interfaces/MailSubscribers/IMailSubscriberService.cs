namespace Victory.Consumers.Desktop.Domain.Interfaces.MailSubscribers;

public interface IMailSubscriberService
{
    Task<List<MailSubscriber>> GetMailSubscriberListAsync();

    Task<MailSubscriber?> GetMailSubscriberAsync(int id, string token);

    Task CreateAsync(MailSubscriber entity);

    Task DeleteAsync(int id, string token);
}