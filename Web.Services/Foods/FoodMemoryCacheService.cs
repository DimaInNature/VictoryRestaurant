namespace Web.Services.Foods;

public class FoodMemoryCacheService : ICacheService<Food>
{
    private readonly IMemoryCache _cache;

    public FoodMemoryCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public bool TryGet(int key, out Food value) =>
        _cache.TryGetValue(key, out value);

    public Food Set(int key, Food value)
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