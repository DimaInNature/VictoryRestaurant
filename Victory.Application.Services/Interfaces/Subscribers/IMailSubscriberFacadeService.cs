namespace Victory.Application.Services.Interfaces;

public interface IMailSubscriberFacadeService
{
    Task<List<MailSubscriberEntity>> GetMailSubscriberListAsync();
    Task<MailSubscriberEntity?> GetMailSubscriberAsync(int id);
    Task CreateAsync(MailSubscriberEntity entity);
    Task UpdateAsync(MailSubscriberEntity entity);
    Task DeleteAsync(int id);
}