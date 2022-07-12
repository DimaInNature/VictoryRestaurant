namespace Victory.Domain.Cache;

public class RedisCacheService<T> : IAsyncCacheService<T> where T : class
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public RedisCacheService(IConnectionMultiplexer connectionMultiplexer) =>
        _connectionMultiplexer = connectionMultiplexer;

    public async Task<T?> GetAsync(string key)
    {
        if (string.IsNullOrWhiteSpace(value: key)) return default;

        IDatabase db = _connectionMultiplexer.GetDatabase();

        string? value = await db.StringGetAsync(key);

        return string.IsNullOrWhiteSpace(value) ? default : JsonConvert.DeserializeObject<T>(value);
    }

    public async Task<bool> SetAsync(string key, T? value)
    {
        if (string.IsNullOrWhiteSpace(value: key) || value is null) return false;

        IDatabase db = _connectionMultiplexer.GetDatabase();

        string serializableValue = JsonConvert.SerializeObject(value);

        TimeSpan expiry = new(days: 1, hours: 0, minutes: 0, seconds: 0);

        return await db.StringSetAsync(key, value: serializableValue, expiry);
    }

    public async Task<bool> RemoveAsync(string key)
    {
        if (string.IsNullOrWhiteSpace(value: key)) return false;

        IDatabase db = _connectionMultiplexer.GetDatabase();

        return await db.KeyDeleteAsync(key);
    }
}