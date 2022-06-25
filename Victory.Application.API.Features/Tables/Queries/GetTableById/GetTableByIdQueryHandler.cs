namespace Victory.Application.API.Features.Tables;

public sealed record class GetTableByIdQueryHandler
    : IRequestHandler<GetTableByIdQuery, TableEntity?>
{
    private readonly ApplicationContext _context;

    public GetTableByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<TableEntity?> Handle(GetTableByIdQuery request, CancellationToken token) =>
        await _context.Tables.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);
}