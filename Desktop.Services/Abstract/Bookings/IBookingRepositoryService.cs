namespace Desktop.Services.Abstract.Bookings;

public interface IBookingRepositoryService
{
    Task<List<Booking>> GetBookingsAsync();
    Task<Booking?> GetBookingAsync(int bookingId);
    Task InsertBookingAsync(Booking booking);
    Task UpdateBookingAsync(Booking booking);
    Task DeleteBookingAsync(int bookingId);
}