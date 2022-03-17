namespace Web.Services.Users;

public class UserMemoryCacheService : ICacheService<User>
{
    private readonly IMemoryCache _cache;

    public UserMemoryCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public bool TryGet(int key, out User value) =>
        _cache.TryGetValue(key, out value);

    public User Set(int key, User value)
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