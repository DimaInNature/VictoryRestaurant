namespace Victory.Application.Web.Interfaces.Data.MailSubscribers;

public interface IMailSubscriberFacadeService
{
    Task<List<MailSubscriber>> GetMailSubscriberListAsync();
    Task<MailSubscriber?> GetMailSubscriberAsync(int id);
    Task DeleteAsync(int id);
}