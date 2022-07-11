namespace Victory.Domain.Features.API.Tables;

public sealed record class GetTableListByNumberQueryHandler
    : IRequestHandler<GetTableListByNumberQuery, List<TableEntity>?>
{
    private readonly ApplicationContext _context;

    public GetTableListByNumberQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<TableEntity>?> Handle(GetTableListByNumberQuery request, CancellationToken token) =>
        await _context.Tables.Where(
            predicate: table => table.Number == request.Number)
        .ToListAsync(cancellationToken: token);
}