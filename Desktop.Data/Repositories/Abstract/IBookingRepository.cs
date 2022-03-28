namespace Desktop.Data.Repositories.Abstract;

public interface IBookingRepository : IDisposable
{
    Task<List<Booking>> GetBookingListAsync();
    Task<Booking> GetBookingAsync(int bookingId);
    Task DeleteAsync(int bookingId);
}