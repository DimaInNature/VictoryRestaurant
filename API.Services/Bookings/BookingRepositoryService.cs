namespace API.Services.Bookings;

public class BookingRepositoryService : IBookingRepositoryService
{
    private readonly IMediator _mediator;

    public BookingRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<BookingEntity>?> GetBookingListAsync() =>
        await _mediator.Send(request: new GetBookingListQuery());

    public async Task<BookingEntity?> GetBookingAsync(int bookingId) =>
        await _mediator.Send(request: new GetBookingByIdQuery(id: bookingId));

    public async Task CreateAsync(BookingEntity booking) =>
        await _mediator.Send(request: new CreateBookingCommand(booking: booking));

    public async Task UpdateAsync(BookingEntity booking) =>
        await _mediator.Send(request: new UpdateBookingCommand(booking: booking));

    public async Task DeleteAsync(int bookingId) =>
        await _mediator.Send(request: new DeleteBookingCommand(id: bookingId));
}