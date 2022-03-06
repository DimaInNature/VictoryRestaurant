namespace Web.Services.Abstract.Bookings;

public interface IBookingFacaceService
{
    Task InsertBookingAsync(Booking booking);
}
