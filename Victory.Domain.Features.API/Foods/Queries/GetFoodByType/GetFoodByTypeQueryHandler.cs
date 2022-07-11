namespace Victory.Domain.Features.API.Foods;

public sealed record class GetFoodByTypeQueryHandler
    : IRequestHandler<GetFoodByTypeQuery, FoodEntity?>
{
    private readonly ApplicationContext _context;

    public GetFoodByTypeQueryHandler(ApplicationContext context) => _context = context;

    public async Task<FoodEntity?> Handle(GetFoodByTypeQuery request, CancellationToken token) =>
        await _context.Foods
        .AsNoTracking()
        .Include(navigationPropertyPath: f => f.FoodType)
        .FirstOrDefaultAsync(predicate: food => food.FoodType.Name == request.Type,
            cancellationToken: token);
}