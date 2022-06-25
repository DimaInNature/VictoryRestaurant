namespace Victory.Application.API.Features.Tables;

public sealed record class UpdateTableCommandHandler
    : IRequestHandler<UpdateTableCommand>
{
    private readonly ApplicationContext _context;

    public UpdateTableCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateTableCommand request, CancellationToken token)
    {
        if (request.Table is null) return Unit.Value;

        var entity = await _context.Tables.FindAsync(
            keyValues: new object[] { request.Table.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.Table.Id;
        entity.Number = request.Table.Number;
        entity.Status = request.Table.Status;
        entity.BookingId = request.Table.BookingId;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}