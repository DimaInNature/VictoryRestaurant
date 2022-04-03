namespace Victory.Application.Services.Features.Foods;

public sealed record class GetFoodListByTypeQuery : IRequest<List<FoodEntity>?>
{
    public FoodType Type { get; }

    public GetFoodListByTypeQuery(FoodType type) => Type = type;

    public GetFoodListByTypeQuery() { }
}