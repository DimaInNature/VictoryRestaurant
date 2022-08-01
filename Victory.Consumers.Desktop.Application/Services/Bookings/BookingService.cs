namespace Victory.Consumers.Desktop.Application.Services.Bookings;

public sealed class BookingService : IBookingService
{
    private readonly IMediator _mediator;

    public BookingService(IMediator mediator) => _mediator = mediator;

    public async Task<List<Booking>> GetBookingListAsync(string token) =>
        await _mediator.Send(request: new GetBookingListQuery(token)) ?? new();

    public async Task<Booking?> GetBookingAsync(int id, string token) =>
        await _mediator.Send(request: new GetBookingByIdQuery(id, token));

    public async Task<Table?> GetBookingTableAsync(int id, string token) =>
        await _mediator.Send(request: new GetBookingTableByIdQuery(id, token));

    public async Task<Booking?> CreateAsync(Booking entity) =>
        await _mediator.Send(request: new CreateBookingCommand(entity));

    public async Task DeleteAsync(int id, string token) =>
        await _mediator.Send(request: new DeleteBookingCommand(id, token));
}