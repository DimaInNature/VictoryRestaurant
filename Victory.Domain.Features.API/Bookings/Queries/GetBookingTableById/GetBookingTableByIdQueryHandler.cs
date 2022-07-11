namespace Victory.Domain.Features.API.Bookings;

public sealed record class GetBookingTableByIdQueryHandler :
    IRequestHandler<GetBookingTableByIdQuery, TableEntity?>
{
    private readonly ApplicationContext _context;

    public GetBookingTableByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<TableEntity?> Handle(GetBookingTableByIdQuery request, CancellationToken token) =>
        await _context.Tables.AsNoTracking()
        .Include(navigationPropertyPath: t => t.Booking)
        .FirstOrDefaultAsync(table => table.BookingId == request.Id,
            cancellationToken: token);
}