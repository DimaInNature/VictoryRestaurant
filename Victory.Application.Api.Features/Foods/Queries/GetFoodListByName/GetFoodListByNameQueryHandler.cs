namespace Victory.Application.Api.Features.Foods;

public sealed record class GetFoodListByNameQueryHandler
    : IRequestHandler<GetFoodListByNameQuery, List<FoodEntity>?>
{
    private readonly ApplicationContext _context;

    public GetFoodListByNameQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<FoodEntity>?> Handle(GetFoodListByNameQuery request, CancellationToken token) =>
        await _context.Foods.Where(
            predicate: food => food.Name.Contains(request.Name ?? string.Empty))
        .ToListAsync(cancellationToken: token);
}