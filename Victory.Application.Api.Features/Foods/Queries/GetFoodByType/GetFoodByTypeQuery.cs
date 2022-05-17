namespace Victory.Application.Api.Features.Foods;

public sealed record class GetFoodByTypeQuery : IRequest<FoodEntity?>
{
    public FoodType Type { get; }

    public GetFoodByTypeQuery(FoodType type) => Type = type;

    public GetFoodByTypeQuery() { }
}