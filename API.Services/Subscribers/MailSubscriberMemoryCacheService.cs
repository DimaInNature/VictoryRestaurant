namespace API.Services.Subscribers;

public class MailSubscriberMemoryCacheService : ICacheService<MailSubscriberEntity>
{
    private readonly IMemoryCache _cache;

    public MailSubscriberMemoryCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public bool TryGet(int key, out MailSubscriberEntity value) =>
        _cache.TryGetValue(key, out value);

    public MailSubscriberEntity Set(int key, MailSubscriberEntity value)
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