namespace Victory.Application.General.Client.Interfaces.Data.MailSubscribers;

public interface IMailSubscriberRepositoryService
{
    Task<List<MailSubscriber>> GetMailSubscriberListAsync();
    Task<MailSubscriber?> GetMailSubscriberAsync(int id);
    Task DeleteAsync(int id);
}