namespace Victory.Application.Desktop.Interfaces;

public interface IBookingFacadeService
{
    Task<List<Booking>> GetBookingListAsync();
    Task<Booking?> GetBookingAsync(int id);
    Task DeleteAsync(int id);
}