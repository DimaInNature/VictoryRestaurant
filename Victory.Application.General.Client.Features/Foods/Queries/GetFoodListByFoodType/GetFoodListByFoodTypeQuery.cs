namespace Victory.Application.General.Client.Features.Foods;

public sealed record class GetFoodListByFoodTypeQuery : IRequest<List<Food>?>
{
    public FoodType FoodType { get; }

    public GetFoodListByFoodTypeQuery(FoodType type) => FoodType = type;

    public GetFoodListByFoodTypeQuery() { }
}