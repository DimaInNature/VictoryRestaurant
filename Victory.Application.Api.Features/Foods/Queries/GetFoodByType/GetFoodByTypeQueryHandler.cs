namespace Victory.Application.API.Features.Foods;

public sealed record class GetFoodByTypeQueryHandler
    : IRequestHandler<GetFoodByTypeQuery, FoodEntity?>
{
    private readonly ApplicationContext _context;

    public GetFoodByTypeQueryHandler(ApplicationContext context) => _context = context;

    public async Task<FoodEntity?> Handle(GetFoodByTypeQuery request, CancellationToken token) =>
        await _context.Foods.FirstOrDefaultAsync(
            predicate: food => food.FoodType.Name == request.Type,
            cancellationToken: token);
}