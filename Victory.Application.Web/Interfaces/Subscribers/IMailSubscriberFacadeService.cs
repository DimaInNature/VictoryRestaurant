namespace Victory.Application.Web.Interfaces;

public interface IMailSubscriberFacadeService
{
    Task CreateAsync(MailSubscriber entity);
}