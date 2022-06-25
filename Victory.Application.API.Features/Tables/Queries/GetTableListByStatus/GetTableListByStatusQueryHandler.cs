namespace Victory.Application.API.Features.Tables;

public sealed record class GetTableListByStatusQueryHandler
    : IRequestHandler<GetTableListByStatusQuery, List<TableEntity>?>
{
    private readonly ApplicationContext _context;

    public GetTableListByStatusQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<TableEntity>?> Handle(GetTableListByStatusQuery request, CancellationToken token) =>
        await _context.Tables.Where(
            predicate: table => table.Status == request.Status)
        .ToListAsync(cancellationToken: token);
}