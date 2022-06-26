namespace Victory.Application.Web.Cache.Tables;

public class TableMemoryCacheService : ICacheService<Table>
{
    private readonly IMemoryCache _cache;

    public TableMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public bool TryGet(int key, out Table value) =>
        _cache.TryGetValue(key, out value);

    public Table Set(int key, Table value)
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