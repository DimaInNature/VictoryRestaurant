namespace Victory.Application.API.Cache.Bookings;

public class BookingMemoryCacheService : ICacheService<BookingEntity>
{
    private readonly IMemoryCache _cache;

    public BookingMemoryCacheService(IMemoryCache cache) => _cache = cache;

    public bool TryGet(int key, out BookingEntity value) =>
        _cache.TryGetValue(key, out value);

    public BookingEntity Set(int key, BookingEntity value)
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