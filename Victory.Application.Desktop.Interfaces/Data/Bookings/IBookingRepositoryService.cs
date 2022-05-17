namespace Victory.Application.Desktop.Interfaces.Data.Bookings;

public interface IBookingRepositoryService
{
    Task<List<Booking>> GetBookingListAsync();
    Task<Booking?> GetBookingAsync(int id);
    Task DeleteAsync(int id);
}