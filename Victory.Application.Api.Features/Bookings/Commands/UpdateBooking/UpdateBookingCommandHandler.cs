namespace Victory.Application.Api.Features.Bookings;

public class UpdateBookingCommandHandler
    : IRequestHandler<UpdateBookingCommand>
{
    private readonly ApplicationContext _context;

    public UpdateBookingCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateBookingCommand request, CancellationToken token)
    {
        if (request.Booking is null) return Unit.Value;

        var entity = await _context.Bookings.FindAsync(
            keyValues: new object[] { request.Booking.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.Booking.Id;
        entity.Name = request.Booking.Name;
        entity.Phone = request.Booking.Phone;
        entity.PersonCount = request.Booking.PersonCount;
        entity.Time = request.Booking.Time;
        entity.DayOfWeek = request.Booking.DayOfWeek;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}