namespace Victory.Application.Api.Cache.Messages;

public class ContactMessageMemoryCacheService : ICacheService<ContactMessageEntity>
{
    private readonly IMemoryCache _cache;

    public ContactMessageMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public bool TryGet(int key, out ContactMessageEntity value) =>
        _cache.TryGetValue(key, out value);

    public ContactMessageEntity Set(int key, ContactMessageEntity value)
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