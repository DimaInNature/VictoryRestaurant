namespace Victory.Application.API.Cache.UserRoles;

public class UserRoleMemoryCacheService : ICacheService<UserRoleEntity>
{
    private readonly IMemoryCache _cache;

    public UserRoleMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public bool TryGet(int key, out UserRoleEntity value) =>
        _cache.TryGetValue(key, out value);

    public UserRoleEntity Set(int key, UserRoleEntity value)
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