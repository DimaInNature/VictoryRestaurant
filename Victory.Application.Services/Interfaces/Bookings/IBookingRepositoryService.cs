namespace Victory.Application.Services.Interfaces;

public interface IBookingRepositoryService
{
    Task<List<BookingEntity>?> GetBookingListAsync();
    Task<BookingEntity?> GetBookingAsync(int id);
    Task CreateAsync(BookingEntity entity);
    Task UpdateAsync(BookingEntity entity);
    Task DeleteAsync(int id);
}