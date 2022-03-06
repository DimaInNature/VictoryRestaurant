namespace Web.Services.Abstract.Bookings;

public interface IBookingRepositoryService
{
    Task InsertBookingAsync(Booking booking);
}
