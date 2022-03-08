namespace Web.Services.Abstract.Subscribers;

public interface IMailSubscriberFacadeService
{
    Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber);
}