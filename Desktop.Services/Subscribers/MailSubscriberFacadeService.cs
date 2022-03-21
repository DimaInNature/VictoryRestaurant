namespace Desktop.Services.Subscribers;

public sealed class MailSubscriberFacadeService : IMailSubscriberFacadeService
{
    private readonly IMailSubscriberRepositoryService _repository;

    public MailSubscriberFacadeService(IMailSubscriberRepositoryService repository)
    {
        _repository = repository;
    }

    public async Task<List<MailSubscriber>> GetMailSubscribersAsync() =>
        await _repository.GetMailSubscribersAsync();

    public async Task<MailSubscriber?> GetMailSubscriberAsync(int mailSubscriberId) =>
        await _repository.GetMailSubscriberAsync(mailSubscriberId);

    public async Task InsertMailSubscriberAsync(MailSubscriber mailSubscriber) =>
        await _repository.InsertMailSubscriberAsync(mailSubscriber);

    public async Task UpdateMailSubscriberAsync(MailSubscriber mailSubscriber) =>
        await _repository.UpdateMailSubscriberAsync(mailSubscriber);

    public async Task DeleteMailSubscriberAsync(int mailSubscriberId) =>
        await _repository.DeleteMailSubscriberAsync(mailSubscriberId);
}