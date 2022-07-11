namespace Victory.Domain.Features.API.Bookings;

public sealed record class DeleteBookingCommandHandler
    : IRequestHandler<DeleteBookingCommand>
{
    private readonly ApplicationContext _context;

    public DeleteBookingCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken token)
    {
        var entity = await _context.Bookings
            .AsNoTracking()
            .FirstOrDefaultAsync(predicate: booking => booking.Id == request.Id,
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.Bookings.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}