namespace API.Features.Foods.Queries;

public sealed record class GetFoodByTypeQueryHandler
    : IRequestHandler<GetFoodByTypeQuery, FoodEntity?>
{
    private readonly ApplicationContext _context;

    public GetFoodByTypeQueryHandler(ApplicationContext context) => _context = context;

    public async Task<FoodEntity?> Handle(GetFoodByTypeQuery request, CancellationToken token) =>
        await _context.Foods.FirstOrDefaultAsync(
            predicate: food => food.Type == request.Type,
            cancellationToken: token);
}