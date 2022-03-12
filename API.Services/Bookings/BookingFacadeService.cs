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

    public async Task<List<BookingEntity>> GetBookingsAsync() =>
        await _repository.GetBookingsAsync();

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

    public async Task InsertBookingAsync(BookingEntity booking)
    {
        await _repository.InsertBookingAsync(booking);

        _cache.Set(key: booking.Id, value: booking);
    }

    public async Task UpdateBookingAsync(BookingEntity booking)
    {
        await _repository.UpdateBookingAsync(booking);

        _cache.Set(key: booking.Id, value: booking);
    }

    public async Task DeleteBookingAsync(int bookingId)
    {
        await _repository.DeleteBookingAsync(bookingId);

        if (_cache.TryGet(key: bookingId, out _))
            _cache.Remove(key: bookingId);
    }

    public async Task<int> SaveAsync() => await _repository.SaveAsync();
}