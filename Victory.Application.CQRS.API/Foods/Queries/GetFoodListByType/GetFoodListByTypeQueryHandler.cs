namespace Victory.Application.CQRS.API.Foods;

public sealed class GetFoodListByTypeQueryHandler
    : IRequestHandler<GetFoodListByTypeQuery, List<FoodEntity>?>
{
    private readonly ApplicationContext _context;

    public GetFoodListByTypeQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<FoodEntity>?> Handle(GetFoodListByTypeQuery request, CancellationToken token) =>
        await _context.Foods.Where(
            predicate: food => food.FoodType.Name == request.Type)
        .ToListAsync(cancellationToken: token);
}