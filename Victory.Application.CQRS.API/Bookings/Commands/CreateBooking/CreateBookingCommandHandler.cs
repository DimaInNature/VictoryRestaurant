namespace Victory.Application.CQRS.API.Bookings;

public class CreateBookingCommandHandler
    : IRequestHandler<CreateBookingCommand>
{
    private readonly ApplicationContext _context;

    public CreateBookingCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateBookingCommand request, CancellationToken token)
    {
        if (request.Booking is null) return Unit.Value;

        await _context.Bookings.AddAsync(
            entity: request.Booking,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}