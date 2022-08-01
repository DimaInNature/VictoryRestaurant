namespace Victory.Consumers.Web.Application.Services.Bookings;

public class BookingService : IBookingService
{
    private readonly IMediator _mediator;

    public BookingService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<Booking?> CreateAsync(Booking entity) =>
        await _mediator.Send(request: new CreateBookingCommand(entity));
}