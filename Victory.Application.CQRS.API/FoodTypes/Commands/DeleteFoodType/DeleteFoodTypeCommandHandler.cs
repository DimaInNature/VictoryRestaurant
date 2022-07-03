namespace Victory.Application.CQRS.API.FoodTypes;

public sealed record class DeleteFoodTypeCommandHandler
    : IRequestHandler<DeleteFoodTypeCommand>
{
    private readonly ApplicationContext _context;

    public DeleteFoodTypeCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(DeleteFoodTypeCommand request, CancellationToken token)
    {
        var foodTypeFromDb = await _context.FoodTypes.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);

        if (foodTypeFromDb is null) return Unit.Value;

        _context.FoodTypes.Remove(foodTypeFromDb);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}