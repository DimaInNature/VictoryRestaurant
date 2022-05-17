namespace Victory.Application.Desktop.Interfaces.Data.Subscribers;

public interface IMailSubscriberRepositoryService
{
    Task<List<MailSubscriber>> GetMailSubscriberListAsync();
    Task<MailSubscriber?> GetMailSubscriberAsync(int id);
    Task DeleteAsync(int id);
}