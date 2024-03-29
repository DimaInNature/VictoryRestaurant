﻿namespace Victory.Domain.Features.API.Foods;

public sealed record class GetFoodListByTypeQuery : IRequest<List<FoodEntity>?>
{
    public string Type { get; } = string.Empty;

    public GetFoodListByTypeQuery(string type) => Type = type;

    public GetFoodListByTypeQuery() { }
}