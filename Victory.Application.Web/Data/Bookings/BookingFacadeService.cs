namespace Victory.Application.Web.Data.Bookings;

public class BookingFacadeService : IBookingFacadeService
{
    private readonly BookingRepositoryServiceLoggerDecorator _repository;

    private readonly ICacheService<Booking> _bookingCache;

    private readonly ICacheService<Table> _tableCache;

    public BookingFacadeService(
        ICacheService<Booking> bookingCache,
        ICacheService<Table> tableCache,
        BookingRepositoryServiceLoggerDecorator repository) =>
        (_bookingCache, _tableCache, _repository) = (bookingCache, tableCache, repository);

    public async Task<List<Booking>> GetBookingListAsync() =>
        await _repository.GetBookingListAsync() ?? new();

    public async Task<Booking?> GetBookingAsync(int id)
    {
        if (_bookingCache.TryGet(id, out var entity)) return entity;

        entity = await _repository.GetBookingAsync(id);

        return entity is null ? null : _bookingCache.Set(key: id, value: entity);
    }

    public async Task<Table?> GetBookingTableAsync(int id)
    {
        if (_tableCache.TryGet(id, out var entity)) return entity;

        entity = await _repository.GetBookingTableAsync(id);

        return entity is null ? null : _tableCache.Set(key: id, value: entity);
    }

    public async Task<Booking?> CreateAsync(Booking entity)
    {
        if (entity is null) return null;

        await _repository.CreateAsync(entity);

        return _bookingCache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        if (_bookingCache.TryGet(key: id, out _))
            _bookingCache.Remove(key: id);
    }
}