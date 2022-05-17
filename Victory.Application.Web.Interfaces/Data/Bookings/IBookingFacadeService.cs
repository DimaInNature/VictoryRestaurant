namespace Victory.Application.Web.Interfaces.Data.Bookings;

public interface IBookingFacadeService
{
    Task CreateAsync(Booking entity);
}