namespace Victory.Domain.Features.API.Bookings;

public sealed record class GetBookingByIdQueryHandler
    : IRequestHandler<GetBookingByIdQuery, BookingEntity?>
{
    private readonly ApplicationContext _context;

    public GetBookingByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<BookingEntity?> Handle(GetBookingByIdQuery request, CancellationToken token) =>
        await _context.Bookings
        .AsNoTracking()
        .Include(navigationPropertyPath: b => b.Table)
        .FirstOrDefaultAsync(predicate: booking => booking.Id == request.Id,
            cancellationToken: token);
}