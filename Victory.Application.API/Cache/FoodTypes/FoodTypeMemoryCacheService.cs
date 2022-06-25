namespace Victory.Application.API.Cache.FoodTypes;

public class FoodTypeMemoryCacheService : ICacheService<FoodTypeEntity>
{
    private readonly IMemoryCache _cache;

    public FoodTypeMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public bool TryGet(int key, out FoodTypeEntity value) =>
        _cache.TryGetValue(key, out value);

    public FoodTypeEntity Set(int key, FoodTypeEntity value)
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