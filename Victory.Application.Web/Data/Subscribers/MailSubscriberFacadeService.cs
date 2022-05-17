namespace Victory.Application.Web.Data.Subscribers;

public class MailSubscriberFacadeService : IMailSubscriberFacadeService
{
    private readonly MailSubscriberRepositoryServiceLoggerDecorator _repository;
    private readonly ICacheService<MailSubscriber> _cache;

    public MailSubscriberFacadeService(ICacheService<MailSubscriber> cache,
        MailSubscriberRepositoryServiceLoggerDecorator repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task CreateAsync(MailSubscriber entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }
}