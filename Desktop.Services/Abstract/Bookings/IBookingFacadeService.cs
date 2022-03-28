namespace Desktop.Services.Abstract.Bookings;

public interface IBookingFacadeService
{
    Task<List<Booking>> GetBookingListAsync();
    Task<Booking?> GetBookingAsync(int bookingId);
    Task DeleteAsync(int bookingId);
}