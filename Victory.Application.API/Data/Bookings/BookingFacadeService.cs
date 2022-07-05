namespace Victory.Application.API.Data.Bookings;

public class BookingFacadeService : IBookingFacadeService
{
    private readonly IBookingRepositoryService _repository;

    private readonly ICacheService<BookingEntity> _bookingCache;

    private readonly ICacheService<TableEntity> _tableCache;

    public BookingFacadeService(IBookingRepositoryService repository,
        ICacheService<BookingEntity> bookingCache, ICacheService<TableEntity> tableCache) =>
        (_repository, _bookingCache, _tableCache) = (repository, bookingCache, tableCache);

    public async Task<IEnumerable<BookingEntity>> GetBookingListAsync() =>
        await _repository.GetBookingListAsync() ?? new();

    public async Task<BookingEntity?> GetBookingAsync(int id)
    {
        if (_bookingCache.TryGet(id, out var entity)) return entity;

        entity = await _repository.GetBookingAsync(id);

        return entity is null ? null : _bookingCache.Set(key: id, value: entity);
    }

    public async Task<TableEntity?> GetBookingTableAsync(int id)
    {
        if (_tableCache.TryGet(id, out var entity)) return entity;

        entity = await _repository.GetBookingTableAsync(id);

        return entity is null ? null : _tableCache.Set(key: id, value: entity);
    }

    public async Task CreateAsync(BookingEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _bookingCache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(BookingEntity entity)
    {
        if (entity is null) return;

        await _repository.UpdateAsync(entity);

        _bookingCache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        if (_bookingCache.TryGet(key: id, out _))
            _bookingCache.Remove(key: id);
    }
}