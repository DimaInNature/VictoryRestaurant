namespace Victory.Domain.Features.API.Tables;

public sealed record class UpdateTableCommandHandler
    : IRequestHandler<UpdateTableCommand>
{
    private readonly ApplicationContext _context;

    public UpdateTableCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateTableCommand request, CancellationToken token)
    {
        if (request.Table is null) return Unit.Value;

        _context.Tables.Attach(entity: request.Table);

        _context.Entry(entity: request.Table).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken: token);
        }
        catch { }

        return Unit.Value;
    }
}