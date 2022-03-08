namespace API.Services.Repositories;

public class MailSubscriberRepositoryService : IMailSubscriberRepositoryService
{
    private readonly IMailSubscriberRepository _repository;

    public MailSubscriberRepositoryService(IMailSubscriberRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MailSubscriberEntity>> GetMailSubscribersAsync() =>
        await _repository.GetMailSubscribersAsync();

    public async Task<MailSubscriberEntity> GetMailSubscriberAsync(int mailSubscriberId) =>
        await _repository.GetMailSubscriberAsync(mailSubscriberId);

    public async Task InsertMailSubscriberAsync(MailSubscriberEntity mailSubscriber) =>
        await _repository.InsertMailSubscriberAsync(mailSubscriber);

    public async Task UpdateMailSubscriberAsync(MailSubscriberEntity mailSubscriber) =>
        await _repository.UpdateMailSubscriberAsync(mailSubscriber);

    public async Task DeleteMailSubscriberAsync(int mailSubscriberId) =>
        await _repository.DeleteMailSubscriberAsync(mailSubscriberId);

    public async Task SaveAsync() => await _repository.SaveAsync();
}