namespace Victory.Application.API.Features.Foods;

public sealed record class UpdateFoodCommandHandler
    : IRequestHandler<UpdateFoodCommand>
{
    private readonly ApplicationContext _context;

    public UpdateFoodCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateFoodCommand request, CancellationToken token)
    {
        if (request.Food is null) return Unit.Value;

        var entityFromDb = await _context.Foods.FindAsync(
            keyValues: new object[] { request.Food.Id },
            cancellationToken: token);

        if (entityFromDb is null) return Unit.Value;

        entityFromDb.Id = request.Food.Id;
        entityFromDb.FoodTypeId = request.Food.FoodTypeId;
        entityFromDb.ImagePath = request.Food.ImagePath;
        entityFromDb.Name = request.Food.Name;
        entityFromDb.CostInUSD = request.Food.CostInUSD;
        entityFromDb.Description = request.Food.Description;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}