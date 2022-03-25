namespace API.Features.Foods.Queries;

public sealed record class GetFoodByIdQueryHandler
    : IRequestHandler<GetFoodByIdQuery, FoodEntity?>
{
    private readonly ApplicationContext _context;

    public GetFoodByIdQueryHandler(ApplicationContext context) => _context = context;

    public async Task<FoodEntity?> Handle(GetFoodByIdQuery request, CancellationToken token) =>
        await _context.Foods.FindAsync(
            keyValues: new object[] { request.Id },
            cancellationToken: token);
}