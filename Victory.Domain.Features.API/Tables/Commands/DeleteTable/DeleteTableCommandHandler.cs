namespace Victory.Domain.Features.API.Tables;

public sealed record class DeleteTableCommandHandler
    : IRequestHandler<DeleteTableCommand>
{
    private readonly ApplicationContext _context;

    public DeleteTableCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteTableCommand request, CancellationToken token)
    {
        var entityFromDb = await _context.Tables
            .AsNoTracking()
            .Include(navigationPropertyPath: t => t.Booking)
            .FirstOrDefaultAsync(predicate: table => table.Id == request.Id,
            cancellationToken: token);

        if (entityFromDb is null) return Unit.Value;

        _context.Tables.Remove(entityFromDb);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}