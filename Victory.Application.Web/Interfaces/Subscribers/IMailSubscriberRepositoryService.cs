namespace Victory.Application.Web.Interfaces;

public interface IMailSubscriberRepositoryService
{
    Task CreateAsync(MailSubscriber entity);
}