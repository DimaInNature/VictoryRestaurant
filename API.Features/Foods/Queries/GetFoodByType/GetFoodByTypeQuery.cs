namespace API.Features.Foods.Queries;

public sealed record class GetFoodByTypeQuery : IRequest<FoodEntity?>
{
    public FoodType Type { get; }

    public GetFoodByTypeQuery(FoodType type) => Type = type;

    public GetFoodByTypeQuery() { }
}