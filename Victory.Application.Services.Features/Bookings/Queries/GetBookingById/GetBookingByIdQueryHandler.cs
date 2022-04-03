namespace Victory.Application.Services.Features.Bookings;

public sealed record class GetBookingByIdQueryHandler
    : IRequestHandler<GetBookingByIdQuery, BookingEntity?>
{
    private readonly ApplicationContext _context;

    public GetBookingByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<BookingEntity?> Handle(GetBookingByIdQuery request, CancellationToken token) =>
        await _context.Bookings.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);
}