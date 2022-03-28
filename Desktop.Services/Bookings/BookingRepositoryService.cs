namespace Desktop.Services.Bookings;

public sealed class BookingRepositoryService : IBookingRepositoryService
{
    private readonly IBookingRepository _repository;

    public BookingRepositoryService(IBookingRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Booking>> GetBookingListAsync() =>
        await _repository.GetBookingListAsync() ?? new();

    public async Task<Booking?> GetBookingAsync(int bookingId)
    {
        if (bookingId < 1) return null;

        return await _repository.GetBookingAsync(bookingId);
    }

    public async Task DeleteAsync(int bookingId)
    {
        if (bookingId < 1) return;

        await _repository.DeleteAsync(bookingId);
    }
}