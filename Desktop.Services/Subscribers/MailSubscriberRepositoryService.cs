namespace Desktop.Services.Subscribers;

public sealed class MailSubscriberRepositoryService : IMailSubscriberRepositoryService
{
    private readonly IMailSubscriberRepository _repository;

    public MailSubscriberRepositoryService(IMailSubscriberRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MailSubscriber>> GetMailSubscriberListAsync() =>
        await _repository.GetMailSubscriberListAsync() ?? new();

    public async Task<MailSubscriber?> GetMailSubscriberAsync(int mailSubscriberId)
    {
        if (mailSubscriberId < 1) return null;

        return await _repository.GetMailSubscriberAsync(mailSubscriberId);
    }

    public async Task DeleteAsync(int mailSubscriberId)
    {
        if (mailSubscriberId < 1) return;

        await _repository.DeleteAsync(mailSubscriberId);
    }
}