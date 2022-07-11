namespace Victory.Domain.Features.API.Foods;

public class GetFoodListQueryHandler
    : IRequestHandler<GetFoodListQuery, List<FoodEntity>?>
{
    private readonly ApplicationContext _context;

    public GetFoodListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<FoodEntity>?> Handle(GetFoodListQuery request, CancellationToken token) =>
        await _context.Foods.ToListAsync(cancellationToken: token);
}