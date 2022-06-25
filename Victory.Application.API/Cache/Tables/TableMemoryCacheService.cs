namespace Victory.Application.API.Cache.Tables;

public class TableMemoryCacheService : ICacheService<TableEntity>
{
    private readonly IMemoryCache _cache;

    public TableMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public bool TryGet(int key, out TableEntity value) =>
        _cache.TryGetValue(key, out value);

    public TableEntity Set(int key, TableEntity value)
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