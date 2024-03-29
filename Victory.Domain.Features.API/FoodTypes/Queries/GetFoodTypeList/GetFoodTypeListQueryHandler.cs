﻿namespace Victory.Domain.Features.API.FoodTypes;

public sealed record class GetFoodTypeListQueryHandler
    : IRequestHandler<GetFoodTypeListQuery, List<FoodTypeEntity>?>
{
    private readonly ApplicationContext _context;

    public GetFoodTypeListQueryHandler(ApplicationContext context) => _context = context;

    public async Task<List<FoodTypeEntity>?> Handle(GetFoodTypeListQuery request, CancellationToken token) =>
        await _context.FoodTypes.AsNoTracking().ToListAsync(cancellationToken: token);
}