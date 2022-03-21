namespace Desktop.Data.Repositories.Abstract;

public interface IBookingRepository : IDisposable
{
    Task<List<Booking>> GetBookingsAsync();
    Task<Booking> GetBookingAsync(int bookingId);
    Task InsertBookingAsync(Booking booking);
    Task UpdateBookingAsync(Booking booking);
    Task DeleteBookingAsync(int bookingId);
}