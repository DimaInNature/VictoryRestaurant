namespace Desktop.Services.Abstract.Bookings;

public interface IBookingRepositoryService
{
    Task<List<Booking>> GetBookingListAsync();
    Task<Booking?> GetBookingAsync(int bookingId);
    Task DeleteAsync(int bookingId);
}