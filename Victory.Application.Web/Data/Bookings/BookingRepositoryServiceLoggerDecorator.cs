namespace Victory.Application.Web.Data.Bookings;

public class BookingRepositoryServiceLoggerDecorator
{
    private readonly IBookingRepositoryService _repository;
    private readonly ILogger<BookingRepositoryServiceLoggerDecorator> _logger;

    public BookingRepositoryServiceLoggerDecorator
        (IBookingRepositoryService repository,
        ILogger<BookingRepositoryServiceLoggerDecorator> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<List<Booking>> GetBookingListAsync()
    {
        List<Booking> result = new();

        try
        {
            result = await _repository.GetBookingListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<Table?> GetBookingTableAsync(int id)
    {
        Table? result = null;

        try
        {
            result = await _repository.GetBookingTableAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<Booking?> GetBookingAsync(int id)
    {
        Booking? result = null;

        try
        {
            result = await _repository.GetBookingAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

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

    public async Task DeleteAsync(int id)
    {
        try
        {
            await _repository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}