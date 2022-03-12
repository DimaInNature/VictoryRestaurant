namespace Web.Services.Bookings;

public class BookingMemoryCacheService : ICacheService<Booking>
{
    private readonly IMemoryCache _cache;

    public BookingMemoryCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public bool TryGet(int key, out Booking value) =>
        _cache.TryGetValue(key, out value);

    public Booking Set(int key, Booking value)
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