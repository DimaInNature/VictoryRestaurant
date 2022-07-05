namespace Victory.Application.API.Cache.Foods;

public class FoodMemoryCacheService : ICacheService<FoodEntity>
{
    private readonly IMemoryCache _cache;

    public FoodMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public bool TryGet(int key, out FoodEntity value) =>
        _cache.TryGetValue(key, out value);

    public FoodEntity Set(int key, FoodEntity value)
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