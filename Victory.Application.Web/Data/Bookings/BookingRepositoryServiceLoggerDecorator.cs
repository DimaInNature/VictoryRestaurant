namespace Victory.Application.Web.Data.Bookings;

public class BookingRepositoryServiceLoggerDecorator
{
    private readonly IBookingRepositoryService _repository;
    private readonly ILogger<BookingRepositoryServiceLoggerDecorator> _logger;

    public BookingRepositoryServiceLoggerDecorator(IBookingRepositoryService repository,
        ILogger<BookingRepositoryServiceLoggerDecorator> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task CreateAsync(Booking booking)
    {
        try
        {
            await _repository.CreateAsync(booking);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}
