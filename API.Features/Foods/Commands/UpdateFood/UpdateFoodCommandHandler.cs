namespace API.Features.Foods.Commands;

public sealed record class UpdateFoodCommandHandler
    : IRequestHandler<UpdateFoodCommand>
{
    private readonly ApplicationContext _context;

    public UpdateFoodCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken token)
    {
        if (request.Food is null) return Unit.Value;

        var entity = await _context.Foods.FindAsync(
            keyValues: new object[] { request.Food.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.Food.Id;
        entity.Type = request.Food.Type;
        entity.ImagePath = request.Food.ImagePath;
        entity.Name = request.Food.Name;
        entity.CostInUSD = request.Food.CostInUSD;
        entity.Description = request.Food.Description;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}