namespace Victory.Application.Desktop.Data.Subscribers;

public sealed class MailSubscriberFacadeService : IMailSubscriberFacadeService
{
    private readonly IMailSubscriberRepositoryService _repository;

    public MailSubscriberFacadeService(IMailSubscriberRepositoryService repository) =>
        _repository = repository;

    public async Task<List<MailSubscriber>> GetMailSubscriberListAsync() =>
        await _repository.GetMailSubscriberListAsync();

    public async Task<MailSubscriber?> GetMailSubscriberAsync(int id, string token) =>
        await _repository.GetMailSubscriberAsync(id, token);

    public async Task CreateAsync(MailSubscriber entity) =>
        await _repository.CreateAsync(entity);

    public async Task DeleteAsync(int id, string token) =>
        await _repository.DeleteAsync(id, token);
}