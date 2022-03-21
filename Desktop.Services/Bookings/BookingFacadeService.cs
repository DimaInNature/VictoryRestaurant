namespace Desktop.Services.Bookings;

public sealed class BookingFacadeService : IBookingFacadeService
{
    private readonly IBookingRepositoryService _repository;

    public BookingFacadeService(IBookingRepositoryService repository)
    {
        _repository = repository;
    }

    public async Task<List<Booking>> GetBookingsAsync() =>
        await _repository.GetBookingsAsync();

    public async Task<Booking?> GetBookingAsync(int bookingId) =>
        await _repository.GetBookingAsync(bookingId);

    public async Task InsertBookingAsync(Booking booking) =>
        await _repository.InsertBookingAsync(booking);

    public async Task UpdateBookingAsync(Booking booking) =>
        await _repository.UpdateBookingAsync(booking);

    public async Task DeleteBookingAsync(int bookingId) =>
        await _repository.DeleteBookingAsync(bookingId);
}