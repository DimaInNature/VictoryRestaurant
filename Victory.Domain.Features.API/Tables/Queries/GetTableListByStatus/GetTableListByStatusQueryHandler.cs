﻿namespace Victory.Domain.Features.API.Tables;

public sealed record class GetTableListByStatusQueryHandler
    : IRequestHandler<GetTableListByStatusQuery, List<TableEntity>?>
{
    private readonly ApplicationContext _context;

    public GetTableListByStatusQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<TableEntity>?> Handle(GetTableListByStatusQuery request, CancellationToken token) =>
        await _context.Tables
        .AsNoTracking()
        .Include(navigationPropertyPath: t => t.Booking)
        .Where(predicate: table => table.Status == request.Status)
        .ToListAsync(cancellationToken: token);
}