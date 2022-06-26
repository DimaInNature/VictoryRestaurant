namespace Victory.Application.General.Client.Services.Data.Bookings;

public sealed class BookingRepositoryService : IBookingRepositoryService
{
    private readonly IMediator _mediator;

    public BookingRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<Booking>> GetBookingListAsync() =>
        await _mediator.Send(request: new GetBookingListQuery()) ?? new();

    public async Task<Booking?> GetBookingAsync(int id) =>
        await _mediator.Send(request: new GetBookingByIdQuery(id));

    public async Task<Table?> GetBookingTableAsync(int id) =>
        await _mediator.Send(request: new GetBookingTableByIdQuery(id));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteBookingCommand(id));
}