namespace API.Services.Abstract.Bookings;

public interface IBookingFacadeService
{
    Task<List<BookingEntity>> GetBookingsAsync();
    Task<BookingEntity> GetBookingAsync(int bookingId);
    Task InsertBookingAsync(BookingEntity booking);
    Task UpdateBookingAsync(BookingEntity booking);
    Task DeleteBookingAsync(int bookingId);
    Task<int> SaveAsync();
}