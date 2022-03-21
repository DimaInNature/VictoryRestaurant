namespace Desktop.Services.Bookings;

public sealed class BookingRepositoryService : IBookingRepositoryService
{
    private readonly IBookingRepository _repository;

    public BookingRepositoryService(IBookingRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Booking>> GetBookingsAsync() =>
        await _repository.GetBookingsAsync() ?? new();

    public async Task<Booking?> GetBookingAsync(int bookingId)
    {
        if (bookingId < 1) return null;

        return await _repository.GetBookingAsync(bookingId);
    }

    public async Task InsertBookingAsync(Booking booking)
    {
        if (booking is null) return;

        await _repository.InsertBookingAsync(booking);
    }

    public async Task UpdateBookingAsync(Booking booking)
    {
        if (booking is null) return;

        await _repository.UpdateBookingAsync(booking);
    }

    public async Task DeleteBookingAsync(int bookingId)
    {
        if (bookingId < 1) return;

        await _repository.DeleteBookingAsync(bookingId);
    }
}