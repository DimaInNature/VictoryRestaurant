namespace Victory.Microservices.SMTP.Domain.Interfaces;

public interface IMailSubscriberService
{
    Task<IEnumerable<MailSubscriberEntity>> GetAllAsync();

    Task<IEnumerable<MailSubscriberEntity>> GetAllAsync(Func<MailSubscriberEntity, bool> predicate);

    Task<MailSubscriberEntity?> GetAsync(int id);

    Task<MailSubscriberEntity?> GetAsync(Func<MailSubscriberEntity, bool> predicate);

    Task CreateAsync(MailSubscriberEntity entity);

    Task UpdateAsync(MailSubscriberEntity entity);

    Task DeleteAsync(int id);
}