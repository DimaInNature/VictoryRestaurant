namespace Victory.Application.Services;

public class UserMemoryCacheService : ICacheService<UserEntity>
{
    private readonly IMemoryCache _cache;

    public UserMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public bool TryGet(int key, out UserEntity value) =>
        _cache.TryGetValue(key, out value);

    public UserEntity Set(int key, UserEntity value)
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