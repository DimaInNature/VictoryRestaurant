namespace Victory.Domain.Features.API.Tables;

public sealed record class GetTableByIdQueryHandler
    : IRequestHandler<GetTableByIdQuery, TableEntity?>
{
    private readonly ApplicationContext _context;

    public GetTableByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<TableEntity?> Handle(GetTableByIdQuery request, CancellationToken token) =>
        await _context.Tables
        .AsNoTracking()
        .Include(navigationPropertyPath: t => t.Booking)
        .FirstOrDefaultAsync(predicate: table => table.Id == request.Id,
            cancellationToken: token);
}