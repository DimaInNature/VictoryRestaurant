namespace Victory.Domain.Features.API.FoodTypes;

public sealed record class UpdateFoodTypeCommandHandler
    : IRequestHandler<UpdateFoodTypeCommand>
{
    private readonly ApplicationContext _context;

    public UpdateFoodTypeCommandHandler(ApplicationContext context) => _context = context;

    public async Task<Unit> Handle(UpdateFoodTypeCommand request, CancellationToken token)
    {
        if (request.FoodType is null) return Unit.Value;

        _context.FoodTypes.Attach(entity: request.FoodType);

        _context.Entry(entity: request.FoodType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(cancellationToken: token);
        }
        catch { }

        return Unit.Value;
    }
}