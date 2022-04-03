namespace Victory.Application.Features.Foods;

public sealed record class GetFoodByFoodTypeQuery : IRequest<Food>
{
    public FoodType FoodType { get; }

    public GetFoodByFoodTypeQuery(FoodType type) => FoodType = type;

    public GetFoodByFoodTypeQuery() { }
}