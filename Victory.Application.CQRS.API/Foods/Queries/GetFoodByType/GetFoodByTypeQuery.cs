namespace Victory.Application.CQRS.API.Foods;

public sealed record class GetFoodByTypeQuery : IRequest<FoodEntity?>
{
    public string Type { get; } = string.Empty;

    public GetFoodByTypeQuery(string type) => Type = type;

    public GetFoodByTypeQuery() { }
}