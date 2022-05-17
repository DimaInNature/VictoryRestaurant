namespace Victory.Application.Web.Data.Bookings;

public class BookingFacadeService : IBookingFacadeService
{
    private readonly BookingRepositoryServiceLoggerDecorator _repository;
    private readonly ICacheService<Booking> _cache;

    public BookingFacadeService(ICacheService<Booking> cache,
        BookingRepositoryServiceLoggerDecorator repository) =>
        (_cache, _repository) = (cache, repository);

    public async Task CreateAsync(Booking entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }
}