namespace Victory.Application.API.Features.Tables;

public sealed record class CreateTableCommandHandler
    : IRequestHandler<CreateTableCommand>
{
    private readonly ApplicationContext _context;

    public CreateTableCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateTableCommand request, CancellationToken token)
    {
        if (request.Table is null) return Unit.Value;

        await _context.Tables.AddAsync(
            entity: request.Table,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}