namespace Victory.Application.API.Features.Foods;

public sealed record class GetFoodListByNameQuery : IRequest<List<FoodEntity>?>
{
    public string? Name { get; }

    public GetFoodListByNameQuery(string name) => Name = name;

    public GetFoodListByNameQuery() { }
}