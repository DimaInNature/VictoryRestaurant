namespace Victory.Application.Web.Interfaces.Data.Subscribers;

public interface IMailSubscriberRepositoryService
{
    Task CreateAsync(MailSubscriber entity);
}