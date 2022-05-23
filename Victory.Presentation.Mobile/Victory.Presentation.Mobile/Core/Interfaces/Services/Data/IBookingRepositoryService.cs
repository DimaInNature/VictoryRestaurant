namespace Victory.Presentation.Mobile.Core.Interfaces.Services.Data;

public interface IBookingRepositoryService
{
    public Task CreateAsync(Booking entity);
}