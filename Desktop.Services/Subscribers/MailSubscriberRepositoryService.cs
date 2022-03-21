namespace Desktop.Services.Subscribers;

public sealed class MailSubscriberRepositoryService : IMailSubscriberRepositoryService
{
    private readonly IMailSubscriberRepository _repository;

    public MailSubscriberRepositoryService(IMailSubscriberRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MailSubscriber>> GetMailSubscribersAsync() =>
        await _repository.GetMailSubscribersAsync() ?? new();

    public async Task<MailSubscriber?> GetMailSubscriberAsync(int mailSubscriberId)
    {
        if (mailSubscriberId < 1) return null;

        return await _repository.GetMailSubscriberAsync(mailSubscriberId);
    }

    public async Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber)
    {
        if (mailSubscriber is null) return;

        await _repository.InsertMailSubscriberAsync(mailSubscriber);
    }

    public async Task UpdateMailSubscriberAsync(MailSubscriber mailSubscriber)
    {
        if (mailSubscriber is null) return;

        await _repository.UpdateMailSubscriberAsync(mailSubscriber);
    }

    public async Task DeleteMailSubscriberAsync(int mailSubscriberId)
    {
        if (mailSubscriberId < 1) return;

        await _repository.DeleteMailSubscriberAsync(mailSubscriberId);
    }
}