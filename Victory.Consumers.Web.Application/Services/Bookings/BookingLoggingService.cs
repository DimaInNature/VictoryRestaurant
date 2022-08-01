namespace Victory.Consumers.Web.Application.Services.Bookings;

public class BookingLoggingService : IBookingService
{
    private readonly IBookingService _repository;

    private readonly ILogger<BookingLoggingService> _logger;

    public BookingLoggingService
        (IBookingService repository,
        ILogger<BookingLoggingService> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<Booking?> CreateAsync(Booking booking)
    {
        try
        {
            return await _repository.CreateAsync(booking);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return null;
        }
    }
}