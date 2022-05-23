namespace Victory.Presentation.Mobile.Services.Data.Repositories;

public sealed class BookingRepositoryService : IBookingRepositoryService, IService
{
    private readonly IMediator _mediator;

    public BookingRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task CreateAsync(Booking entity) =>
        await _mediator.Send(request: new CreateBookingCommand(entity));
}