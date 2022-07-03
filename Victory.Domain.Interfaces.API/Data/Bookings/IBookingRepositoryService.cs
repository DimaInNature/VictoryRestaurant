namespace Victory.Domain.Interfaces.API.Data.Bookings;

public interface IBookingRepositoryService
{
    Task<List<BookingEntity>?> GetBookingListAsync();
    Task<BookingEntity?> GetBookingAsync(int id);
    Task<TableEntity?> GetBookingTableAsync(int id);
    Task CreateAsync(BookingEntity entity);
    Task UpdateAsync(BookingEntity entity);
    Task DeleteAsync(int id);
}