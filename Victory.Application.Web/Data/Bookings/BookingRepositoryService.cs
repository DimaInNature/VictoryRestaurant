namespace Victory.Application.Web.Data.Bookings;

public class BookingRepositoryService : IBookingRepositoryService
{
    private readonly IMediator _mediator;

    public BookingRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task CreateAsync(Booking entity) =>
        await _mediator.Send(request: new CreateBookingCommand(entity));
}