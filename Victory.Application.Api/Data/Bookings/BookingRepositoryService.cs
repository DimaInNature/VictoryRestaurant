namespace Victory.Application.Api.Data.Bookings;

public class BookingRepositoryService : IBookingRepositoryService
{
    private readonly IMediator _mediator;

    public BookingRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<BookingEntity>?> GetBookingListAsync() =>
        await _mediator.Send(request: new GetBookingListQuery());

    public async Task<BookingEntity?> GetBookingAsync(int id) =>
        await _mediator.Send(request: new GetBookingByIdQuery(id));

    public async Task CreateAsync(BookingEntity entity) =>
        await _mediator.Send(request: new CreateBookingCommand(entity));

    public async Task UpdateAsync(BookingEntity entity) =>
        await _mediator.Send(request: new UpdateBookingCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteBookingCommand(id));
}