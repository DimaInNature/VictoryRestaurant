namespace API.Services.Abstract.Bookings;

public interface IBookingRepositoryService
{
    Task<List<BookingEntity>?> GetBookingListAsync();
    Task<BookingEntity?> GetBookingAsync(int bookingId);
    Task CreateAsync(BookingEntity booking);
    Task UpdateAsync(BookingEntity booking);
    Task DeleteAsync(int bookingId);
}