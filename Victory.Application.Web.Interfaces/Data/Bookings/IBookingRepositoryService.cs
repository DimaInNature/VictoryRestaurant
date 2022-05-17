namespace Victory.Application.Web.Interfaces.Data.Bookings;

public interface IBookingRepositoryService
{
    Task CreateAsync(Booking entity);
}