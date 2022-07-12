namespace Victory.Domain.API.Decorators.Bookings;

public class BookingRepositoryCacheService : IBookingRepositoryService
{
    private const string NameForBookingCaching = "Booking";

    private const string NameForTableCaching = "Table";

    private readonly IBookingRepositoryService _repository;

    private readonly IAsyncCacheService<BookingEntity> _bookingCache;

    private readonly IAsyncCacheService<TableEntity> _tableCache;

    public BookingRepositoryCacheService(IBookingRepositoryService repository,
        IAsyncCacheService<BookingEntity> bookingCache, IAsyncCacheService<TableEntity> tableCache) =>
        (_repository, _bookingCache, _tableCache) = (repository, bookingCache, tableCache);

    public async Task<List<BookingEntity>?> GetBookingListAsync() =>
        await _repository.GetBookingListAsync() ?? new();

    public async Task<BookingEntity?> GetBookingAsync(int id)
    {
        BookingEntity? entityFromCache = await _bookingCache.GetAsync(key: $"{NameForBookingCaching}_{id}");

        if (entityFromCache is not null) return entityFromCache;

        BookingEntity? entityFromDb = await _repository.GetBookingAsync(id);

        if (entityFromDb is null) return null;

        await _bookingCache.SetAsync(key: $"{NameForBookingCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task<TableEntity?> GetBookingTableAsync(int id)
    {
        TableEntity? entityFromDb = await _repository.GetBookingTableAsync(id);

        if (entityFromDb is null) return null;

        await _tableCache.SetAsync(key: $"{NameForTableCaching}_{entityFromDb.Id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task CreateAsync(BookingEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    public async Task UpdateAsync(BookingEntity entity)
    {
        if (entity is null) return;

        await _bookingCache.SetAsync(key: $"{NameForBookingCaching}_{entity.Id}", value: entity);

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        await _bookingCache.RemoveAsync(key: $"{NameForBookingCaching}_{id}");
    }
}