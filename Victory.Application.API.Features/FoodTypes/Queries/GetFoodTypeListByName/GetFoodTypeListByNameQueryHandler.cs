﻿namespace Victory.Application.API.Features.FoodTypes;

public sealed record class GetFoodTypeListByNameQueryHandler
    : IRequestHandler<GetFoodTypeListByNameQuery, List<FoodTypeEntity>?>
{
    private readonly ApplicationContext _context;

    public GetFoodTypeListByNameQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<FoodTypeEntity>?> Handle(GetFoodTypeListByNameQuery request, CancellationToken token) =>
        await _context.FoodTypes.Where(
            predicate: foodType => foodType.Name.Contains(request.Name ?? string.Empty))
        .ToListAsync(cancellationToken: token);
}