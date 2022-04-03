namespace Victory.Application.Web.Interfaces;

public interface IBookingRepositoryService
{
    Task CreateAsync(Booking entity);
}