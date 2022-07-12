namespace Victory.Domain.Consumers.Decorators.Bookings;

public class BookingRepositoryCacheService : IBookingRepositoryService
{
    private const string NameForCaching = "Booking";

    private readonly IBookingRepositoryService _repository;

    private readonly ISyncCacheService<Booking> _bookingCache;

    private readonly ISyncCacheService<Table> _tableCache;

    public BookingRepositoryCacheService(
        ISyncCacheService<Booking> bookingCache,
        ISyncCacheService<Table> tableCache,
        IBookingRepositoryService repository) =>
        (_bookingCache, _tableCache, _repository) = (bookingCache, tableCache, repository);

    public async Task<List<Booking>> GetBookingListAsync(string token) =>
        await _repository.GetBookingListAsync(token) ?? new();

    public async Task<Booking?> GetBookingAsync(int id, string token)
    {
        Booking? cached = _bookingCache.Get(key: $"{NameForCaching}_{id}");

        if (cached is not null) return cached;

        Booking? entityFromDb = await _repository.GetBookingAsync(id, token);

        if (entityFromDb is null) return null;

        _bookingCache.Set(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task<Table?> GetBookingTableAsync(int id, string token)
    {
        Table? cached = _tableCache.Get(key: id.ToString());

        if (cached is not null) return cached;

        Table? entityFromDb = await _repository.GetBookingTableAsync(id, token);

        if (entityFromDb is null) return null;

        _tableCache.Set(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task<Booking?> CreateAsync(Booking entity)
    {
        if (entity is null) return null;

        Booking? entityFromDb = await _repository.CreateAsync(entity);

        if (entityFromDb is null) return null;

        _bookingCache.Set(key: $"{NameForCaching}_{entityFromDb.Id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task DeleteAsync(int id, string token)
    {
        await _repository.DeleteAsync(id, token);

        _bookingCache.Remove(key: $"{NameForCaching}_{id}");
    }
}