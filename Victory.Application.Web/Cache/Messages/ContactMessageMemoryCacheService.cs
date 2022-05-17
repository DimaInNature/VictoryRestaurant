namespace Victory.Application.Web.Cache.Messages;

public class ContactMessageMemoryCacheService : ICacheService<ContactMessage>
{
    private readonly IMemoryCache _cache;

    public ContactMessageMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public bool TryGet(int key, out ContactMessage value) =>
        _cache.TryGetValue(key, out value);

    public ContactMessage Set(int key, ContactMessage value)
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