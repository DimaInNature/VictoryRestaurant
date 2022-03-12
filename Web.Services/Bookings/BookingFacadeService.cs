namespace Web.Services.Bookings;

public class BookingFacadeService : IBookingFacaceService
{
    private readonly BookingRepositoryServiceLoggerDecorator _repository;
    private readonly ICacheService<Booking> _cache;

    public BookingFacadeService(ICacheService<Booking> cache,
        BookingRepositoryServiceLoggerDecorator repositoryService)
    {
        _repository = repositoryService;
        _cache = cache;
    }

    public async Task InsertBookingAsync(Booking booking)
    {
        await _repository.InsertBookingAsync(booking);

        _cache.Set(key: booking.Id, value: booking);
    }
}