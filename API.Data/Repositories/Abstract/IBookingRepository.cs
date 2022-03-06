namespace API.Data.Repositories.Abstract;

public interface IBookingRepository : IDisposable
{
    Task<List<BookingEntity>> GetBookingsAsync();
    Task<BookingEntity> GetBookingAsync(int bookingId);
    Task InsertBookingAsync(BookingEntity booking);
    Task UpdateBookingAsync(BookingEntity booking);
    Task DeleteBookingAsync(int bookingId);
    Task SaveAsync();
}