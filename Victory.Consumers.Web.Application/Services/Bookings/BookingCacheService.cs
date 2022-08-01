namespace Victory.Consumers.Web.Application.Services.Bookings;

public class BookingCacheService : IBookingService
{
    private const string NameForCaching = "Booking";

    private readonly IBookingService _repository;

    private readonly ISyncCacheService<Booking> _bookingCache;

    public BookingCacheService(
        ISyncCacheService<Booking> bookingCache,
        IBookingService repository) =>
        (_bookingCache, _repository) = (bookingCache, repository);

    public async Task<Booking?> CreateAsync(Booking entity)
    {
        if (entity is null) return null;

        Booking? entityFromDb = await _repository.CreateAsync(entity);

        if (entityFromDb is null) return null;

        _bookingCache.Set(key: $"{NameForCaching}_{entityFromDb.Id}", value: entityFromDb);

        return entityFromDb;
    }
}