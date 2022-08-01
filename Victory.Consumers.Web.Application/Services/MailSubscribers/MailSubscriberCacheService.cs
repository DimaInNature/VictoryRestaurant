namespace Victory.Consumers.Web.Application.Services.MailSubscribers;

public class MailSubscriberCacheService : IMailSubscriberService
{
    private const string NameForCaching = "MailSubscriber";

    private readonly IMailSubscriberService _repository;

    private readonly ISyncCacheService<MailSubscriber> _cache;

    public MailSubscriberCacheService(
        ISyncCacheService<MailSubscriber> cache,
        IMailSubscriberService repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task CreateAsync(MailSubscriber entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }
}