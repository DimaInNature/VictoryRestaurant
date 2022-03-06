namespace Web.Services.Bookings;

public class BookingRepositoryService : IBookingRepositoryService
{
    private readonly IBookingRepository _repository;

    public BookingRepositoryService(IBookingRepository repository)
    {
        _repository = repository;
    }

    public async Task InsertBookingAsync(Booking booking) =>
        await _repository.InsertBookingAsync(booking.ToEntity());
}
