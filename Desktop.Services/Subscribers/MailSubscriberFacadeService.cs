namespace Desktop.Services.Subscribers;

public sealed class MailSubscriberFacadeService : IMailSubscriberFacadeService
{
    private readonly IMailSubscriberRepositoryService _repository;

    public MailSubscriberFacadeService(IMailSubscriberRepositoryService repository)
    {
        _repository = repository;
    }

    public async Task<List<MailSubscriber>> GetMailSubscriberListAsync() =>
        await _repository.GetMailSubscriberListAsync();

    public async Task<MailSubscriber?> GetMailSubscriberAsync(int mailSubscriberId) =>
        await _repository.GetMailSubscriberAsync(mailSubscriberId);

    public async Task DeleteAsync(int mailSubscriberId) =>
        await _repository.DeleteAsync(mailSubscriberId);
}