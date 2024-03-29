﻿namespace Victory.Domain.Features.API.Bookings;

public sealed record class GetBookingListQueryHandler
    : IRequestHandler<GetBookingListQuery, List<BookingEntity>?>
{
    private readonly ApplicationContext _context;

    public GetBookingListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<BookingEntity>?> Handle(GetBookingListQuery request, CancellationToken token) =>
        await _context.Bookings
        .AsNoTracking()
        .Include(navigationPropertyPath: b => b.Table)
        .ToListAsync(cancellationToken: token);
}