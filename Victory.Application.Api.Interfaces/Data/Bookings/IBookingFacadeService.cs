namespace Victory.Application.API.Interfaces.Data.Bookings;

public interface IBookingFacadeService
{
    Task<IEnumerable<BookingEntity>> GetBookingListAsync();
    Task<BookingEntity?> GetBookingAsync(int bookingId);
    Task<TableEntity?> GetBookingTableAsync(int bookingId);
    Task CreateAsync(BookingEntity entity);
    Task UpdateAsync(BookingEntity entity);
    Task DeleteAsync(int bookingId);
}