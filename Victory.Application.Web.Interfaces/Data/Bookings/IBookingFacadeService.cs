namespace Victory.Application.Web.Interfaces.Data.Bookings;

public interface IBookingFacadeService
{
    Task<List<Booking>> GetBookingListAsync();
    Task<Booking?> GetBookingAsync(int id);
    Task<Table?> GetBookingTableAsync(int id);
    Task<Booking?> CreateAsync(Booking entity);
    Task DeleteAsync(int id);
}