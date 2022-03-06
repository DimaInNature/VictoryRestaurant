namespace Web.Services.Bookings;

public class BookingFacadeService : IBookingFacaceService
{
    private readonly BookingRepositoryServiceLoggerDecorator _repositoryService;

    public BookingFacadeService(BookingRepositoryServiceLoggerDecorator repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task InsertBookingAsync(Booking booking) =>
        await _repositoryService.InsertBookingAsync(booking);
}
