namespace Web.Services.Abstract.Subscribers;

public interface IMailSubscriberRepositoryService
{
    Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber);
}