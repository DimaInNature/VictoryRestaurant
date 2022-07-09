namespace Victory.Application.CQRS.API.FoodTypes;

public sealed record class GetFoodTypeByIdQueryHandler
    : IRequestHandler<GetFoodTypeByIdQuery, FoodTypeEntity?>
{
    private readonly ApplicationContext _context;

    public GetFoodTypeByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<FoodTypeEntity?> Handle(GetFoodTypeByIdQuery request, CancellationToken token) =>
        await _context.FoodTypes.AsNoTracking()
        .FirstOrDefaultAsync(predicate: foodType => foodType.Id == request.Id,
            cancellationToken: token);
}