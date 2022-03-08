namespace Web.Data.Repositories.Abstract;

public interface IMailSubscriberRepository
{
    Task InsertMailSubscriberAsync(MailSubscriberEntity mailSubscriber);
}