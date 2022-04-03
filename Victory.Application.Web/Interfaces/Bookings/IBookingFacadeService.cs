namespace Victory.Application.Web.Interfaces;

public interface IBookingFacadeService
{
    Task CreateAsync(Booking entity);
}