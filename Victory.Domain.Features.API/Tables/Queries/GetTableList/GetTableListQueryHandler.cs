namespace Victory.Domain.Features.API.Tables;

public sealed record class GetTableListQueryHandler
    : IRequestHandler<GetTableListQuery, List<TableEntity>?>
{
    private readonly ApplicationContext _context;

    public GetTableListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<TableEntity>?> Handle(GetTableListQuery request, CancellationToken token) =>
        await _context.Tables.ToListAsync(cancellationToken: token);
}