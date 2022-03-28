namespace Desktop.Services.Bookings;

public sealed class BookingFacadeService : IBookingFacadeService
{
    private readonly IBookingRepositoryService _repository;

    public BookingFacadeService(IBookingRepositoryService repository)
    {
        _repository = repository;
    }

    public async Task<List<Booking>> GetBookingListAsync() =>
        await _repository.GetBookingListAsync();

    public async Task<Booking?> GetBookingAsync(int bookingId) =>
        await _repository.GetBookingAsync(bookingId);

    public async Task DeleteAsync(int bookingId) =>
        await _repository.DeleteAsync(bookingId);
}