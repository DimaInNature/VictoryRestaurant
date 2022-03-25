namespace API.Services.Bookings;

public class BookingFacadeService : IBookingFacadeService
{
    private readonly IBookingRepositoryService _repository;
    private readonly ICacheService<BookingEntity> _cache;

    public BookingFacadeService(IBookingRepositoryService repository,
        ICacheService<BookingEntity> cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<List<BookingEntity>> GetBookingListAsync() =>
        await _repository.GetBookingListAsync();

    public async Task<BookingEntity> GetBookingAsync(int bookingId)
    {
        if (_cache.TryGet(bookingId, out var booking))
            return booking;
        else
        {
            booking = await _repository.GetBookingAsync(bookingId);

            return _cache.Set(key: bookingId, value: booking);
        }
    }

    public async Task CreateAsync(BookingEntity booking)
    {
        await _repository.CreateAsync(booking);

        _cache.Set(key: booking.Id, value: booking);
    }

    public async Task UpdateAsync(BookingEntity booking)
    {
        await _repository.UpdateAsync(booking);

        _cache.Set(key: booking.Id, value: booking);
    }

    public async Task DeleteAsync(int bookingId)
    {
        await _repository.DeleteAsync(bookingId);

        if (_cache.TryGet(key: bookingId, out _))
            _cache.Remove(key: bookingId);
    }
}