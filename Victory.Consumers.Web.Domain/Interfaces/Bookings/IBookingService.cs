namespace Victory.Consumers.Web.Domain.Interfaces.Bookings;

public interface IBookingService
{
    Task<Booking?> CreateAsync(Booking entity);
}