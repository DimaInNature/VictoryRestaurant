namespace Victory.Domain.Interfaces.Consumers.Data.MailSubscribers;

public interface IMailSubscriberRepositoryService
{
    Task<List<MailSubscriber>> GetMailSubscriberListAsync();
    Task<MailSubscriber?> GetMailSubscriberAsync(int id, string token);
    Task CreateAsync(MailSubscriber entity);
    Task DeleteAsync(int id, string token);
}