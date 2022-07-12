namespace Victory.Domain.Consumers.Decorators.Bookings;

public class BookingRepositoryLoggingService : IBookingRepositoryService
{
    private readonly IBookingRepositoryService _repository;

    private readonly ILogger<BookingRepositoryLoggingService> _logger;

    public BookingRepositoryLoggingService
        (IBookingRepositoryService repository,
        ILogger<BookingRepositoryLoggingService> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<List<Booking>> GetBookingListAsync(string token)
    {
        List<Booking> result = new();

        try
        {
            result = await _repository.GetBookingListAsync(token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<Table?> GetBookingTableAsync(int id, string token)
    {
        Table? result = null;

        try
        {
            result = await _repository.GetBookingTableAsync(id, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<Booking?> GetBookingAsync(int id, string token)
    {
        Booking? result = null;

        try
        {
            result = await _repository.GetBookingAsync(id, token);
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

    public async Task DeleteAsync(int id, string token)
    {
        try
        {
            await _repository.DeleteAsync(id, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}