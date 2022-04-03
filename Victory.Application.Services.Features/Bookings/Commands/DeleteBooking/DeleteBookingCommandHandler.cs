namespace Victory.Application.Services.Features.Bookings;

public sealed record class DeleteBookingCommandHandler
    : IRequestHandler<DeleteBookingCommand>
{
    private readonly ApplicationContext _context;

    public DeleteBookingCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken token)
    {
        var entity = await _context.Bookings.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        _context.Bookings.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}