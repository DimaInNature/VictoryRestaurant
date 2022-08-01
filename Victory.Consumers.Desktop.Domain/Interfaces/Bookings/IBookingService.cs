namespace Victory.Consumers.Desktop.Domain.Interfaces.Bookings;

public interface IBookingService
{
    Task<List<Booking>> GetBookingListAsync(string token);

    Task<Booking?> GetBookingAsync(int id, string token);

    Task<Table?> GetBookingTableAsync(int id, string token);

    Task<Booking?> CreateAsync(Booking entity);

    Task DeleteAsync(int id, string token);
}