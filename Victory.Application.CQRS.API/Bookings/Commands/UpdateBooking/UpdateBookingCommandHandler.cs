namespace Victory.Application.CQRS.API.Bookings;

public class UpdateBookingCommandHandler
    : IRequestHandler<UpdateBookingCommand>
{
    private readonly ApplicationContext _context;

    public UpdateBookingCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateBookingCommand request, CancellationToken token)
    {
        if (request.Booking is null) return Unit.Value;

        _context.Bookings.Attach(entity: request.Booking);

        _context.Entry(entity: request.Booking).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken: token);
        }
        catch { }

        return Unit.Value;
    }
}