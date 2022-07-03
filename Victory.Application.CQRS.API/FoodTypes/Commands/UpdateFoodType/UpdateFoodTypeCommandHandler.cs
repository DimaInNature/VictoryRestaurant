namespace Victory.Application.CQRS.API.FoodTypes;

public sealed record class UpdateFoodTypeCommandHandler
    : IRequestHandler<UpdateFoodTypeCommand>
{
    private readonly ApplicationContext _context;

    public UpdateFoodTypeCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateFoodTypeCommand request, CancellationToken token)
    {
        if (request.FoodType is null) return Unit.Value;

        var entity = await _context.FoodTypes.FindAsync(
            keyValues: new object[] { request.FoodType.Id },
            cancellationToken: token);

        if (entity is null) return Unit.Value;

        entity.Id = request.FoodType.Id;
        entity.Name = request.FoodType.Name;

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}