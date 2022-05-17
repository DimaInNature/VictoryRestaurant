namespace Victory.Application.Web.Interfaces.Data.Subscribers;

public interface IMailSubscriberFacadeService
{
    Task CreateAsync(MailSubscriber entity);
}