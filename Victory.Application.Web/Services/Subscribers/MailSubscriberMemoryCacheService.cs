namespace Victory.Application.Web.Services;

public class MailSubscriberMemoryCacheService : ICacheService<MailSubscriber>
{
    private readonly IMemoryCache _cache;

    public MailSubscriberMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public bool TryGet(int key, out MailSubscriber value) =>
        _cache.TryGetValue(key, out value);

    public MailSubscriber Set(int key, MailSubscriber value)
    {
        if (TryGet(key, out _) is false)
            _cache.Set(key, value);

        return value;
    }

    public void Remove(int key)
    {
        if (TryGet(key, out _))
            _cache.Remove(key);
    }
}