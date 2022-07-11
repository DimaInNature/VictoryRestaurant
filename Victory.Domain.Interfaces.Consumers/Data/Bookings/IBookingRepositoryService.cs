namespace Victory.Domain.Interfaces.Consumers.Data.Bookings;

public interface IBookingRepositoryService
{
    Task<List<Booking>> GetBookingListAsync(string token);
    Task<Booking?> GetBookingAsync(int id, string token);
    Task<Table?> GetBookingTableAsync(int id, string token);
    Task<Booking?> CreateAsync(Booking entity);
    Task DeleteAsync(int id, string token);
}