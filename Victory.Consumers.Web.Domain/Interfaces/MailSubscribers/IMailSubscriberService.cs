namespace Victory.Consumers.Web.Domain.Interfaces.MailSubscribers;

public interface IMailSubscriberService
{
    Task CreateAsync(MailSubscriber entity);
}