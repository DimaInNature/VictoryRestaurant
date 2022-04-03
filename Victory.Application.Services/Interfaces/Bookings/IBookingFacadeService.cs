namespace Victory.Application.Services.Interfaces;

public interface IBookingFacadeService
{
    Task<IEnumerable<BookingEntity>> GetBookingListAsync();
    Task<BookingEntity?> GetBookingAsync(int bookingId);
    Task CreateAsync(BookingEntity booking);
    Task UpdateAsync(BookingEntity booking);
    Task DeleteAsync(int bookingId);
}