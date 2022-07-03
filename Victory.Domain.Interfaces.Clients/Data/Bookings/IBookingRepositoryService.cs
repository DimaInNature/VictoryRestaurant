namespace Victory.Domain.Interfaces.Clients.Data.Bookings;

public interface IBookingRepositoryService
{
    Task<List<Booking>> GetBookingListAsync();
    Task<Booking?> GetBookingAsync(int id);
    Task<Table?> GetBookingTableAsync(int id);
    Task<Booking?> CreateAsync(Booking entity);
    Task DeleteAsync(int id);
}