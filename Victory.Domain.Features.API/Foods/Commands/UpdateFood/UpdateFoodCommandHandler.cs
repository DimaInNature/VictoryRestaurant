namespace Victory.Domain.Features.API.Foods;

public sealed record class UpdateFoodCommandHandler
    : IRequestHandler<UpdateFoodCommand>
{
    private readonly ApplicationContext _context;

    public UpdateFoodCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken token)
    {
        if (request.Food is null) return Unit.Value;

        _context.Foods.Attach(entity: request.Food);

        _context.Entry(entity: request.Food).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken: token);
        }
        catch { }

        return Unit.Value;
    }
}