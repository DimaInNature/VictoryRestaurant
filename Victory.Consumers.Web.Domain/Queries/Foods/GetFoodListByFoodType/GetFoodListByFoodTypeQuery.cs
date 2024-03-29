﻿namespace Victory.Consumers.Web.Domain.Queries.Foods;

public sealed record class GetFoodListByFoodTypeQuery
    : BaseAnonymousFeature, IRequest<List<Food>?>
{
    public FoodType? FoodType { get; }

    public GetFoodListByFoodTypeQuery(FoodType type) => FoodType = type;

    public GetFoodListByFoodTypeQuery() { }
}