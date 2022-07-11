namespace Victory.Domain.Features.API.Foods;

public sealed record class GetFoodByIdQueryHandler
    : IRequestHandler<GetFoodByIdQuery, FoodEntity?>
{
    private readonly ApplicationContext _context;

    public GetFoodByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<FoodEntity?> Handle(GetFoodByIdQuery request, CancellationToken token) =>
        await _context.Foods.AsNoTracking()
        .Include(navigationPropertyPath: f => f.FoodType)
        .FirstOrDefaultAsync(predicate: food => food.Id == request.Id,
            cancellationToken: token);
}