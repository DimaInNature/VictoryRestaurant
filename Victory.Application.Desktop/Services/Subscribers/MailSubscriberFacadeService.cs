namespace Victory.Application.Desktop.Services;

public sealed class MailSubscriberFacadeService : IMailSubscriberFacadeService
{
    private readonly IMailSubscriberRepositoryService _repository;

    public MailSubscriberFacadeService(IMailSubscriberRepositoryService repository) =>
        _repository = repository;

    public async Task<List<MailSubscriber>> GetMailSubscriberListAsync() =>
        await _repository.GetMailSubscriberListAsync();

    public async Task<MailSubscriber?> GetMailSubscriberAsync(int id) =>
        await _repository.GetMailSubscriberAsync(id);

    public async Task DeleteAsync(int id) =>
        await _repository.DeleteAsync(id);
}