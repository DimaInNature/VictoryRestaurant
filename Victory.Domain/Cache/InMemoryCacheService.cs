namespace Victory.Domain.Cache;

public class InMemoryCacheService<T> : ISyncCacheService<T> where T : class
{
    private readonly IMemoryCache _cache;

    public InMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public T? Get(string key)
    {
        _cache.TryGetValue(key, out T? value);

        return value;
    }

    public bool Set(string key, T? value)
    {
        if (value is null) return false;

        TimeSpan expiry = new(days: 1, hours: 0, minutes: 0, seconds: 0);

        _cache.Set(key, value, absoluteExpirationRelativeToNow: expiry);

        return _cache.TryGetValue(key, out _);
    }

    public bool Remove(string key)
    {
        _cache.Remove(key);

        return _cache.TryGetValue(key, value: out _) is false;
    }
}