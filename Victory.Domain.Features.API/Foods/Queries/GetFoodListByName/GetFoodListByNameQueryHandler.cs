﻿namespace Victory.Domain.Features.API.Foods;

public sealed record class GetFoodListByNameQueryHandler
    : IRequestHandler<GetFoodListByNameQuery, List<FoodEntity>?>
{
    private readonly ApplicationContext _context;

    public GetFoodListByNameQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<FoodEntity>?> Handle(GetFoodListByNameQuery request, CancellationToken token) =>
        await _context.Foods
        .AsNoTracking()
        .Include(navigationPropertyPath: f => f.FoodType)
        .Where(predicate: food => food.Name.Contains(request.Name ?? string.Empty))
        .ToListAsync(cancellationToken: token);
}