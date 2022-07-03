namespace Victory.Application.CQRS.API.FoodTypes;

public sealed record class CreateFoodTypeCommandHandler
    : IRequestHandler<CreateFoodTypeCommand>
{
    private readonly ApplicationContext _context;

    public CreateFoodTypeCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(CreateFoodTypeCommand request, CancellationToken token)
    {
        if (request.FoodType is null) return Unit.Value;

        await _context.FoodTypes.AddAsync(
            entity: request.FoodType,
            cancellationToken: token);

        await _context.SaveChangesAsync(cancellationToken: token);

        return Unit.Value;
    }
}