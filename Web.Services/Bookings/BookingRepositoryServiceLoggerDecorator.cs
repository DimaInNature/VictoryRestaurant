namespace Web.Services.Bookings;

public class BookingRepositoryServiceLoggerDecorator
{
    private readonly IBookingRepositoryService _repositoryService;
    private readonly ILogger<BookingRepositoryServiceLoggerDecorator> _logger;

    public BookingRepositoryServiceLoggerDecorator(IBookingRepositoryService repositoryService,
        ILogger<BookingRepositoryServiceLoggerDecorator> logger)
    {
        _repositoryService = repositoryService;
        _logger = logger;
    }

    public async Task InsertBookingAsync(Booking booking)
    {
        try
        {
            await _repositoryService.InsertBookingAsync(booking);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}
