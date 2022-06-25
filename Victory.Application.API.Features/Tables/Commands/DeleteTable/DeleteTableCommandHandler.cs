namespace Victory.Application.API.Features.Tables;

public sealed record class DeleteTableCommandHandler
    : IRequestHandler<DeleteTableCommand>
{
    private readonly ApplicationContext _context;

    public DeleteTableCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteTableCommand request, CancellationToken token)
    {
        var entityFromDb = await _context.Tables.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (entityFromDb is null) return Unit.Value;

        _context.Tables.Remove(entityFromDb);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}