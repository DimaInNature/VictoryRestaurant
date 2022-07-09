namespace Victory.Domain.Interfaces.Clients.Data.Bookings;

public interface IBookingFacadeService
{
    Task<List<Booking>> GetBookingListAsync(string token);
    Task<Booking?> GetBookingAsync(int id, string token);
    Task<Table?> GetBookingTableAsync(int id, string token);
    Task<Booking?> CreateAsync(Booking entity);
    Task DeleteAsync(int id, string token);
}