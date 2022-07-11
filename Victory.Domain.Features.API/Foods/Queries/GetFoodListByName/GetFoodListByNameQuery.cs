namespace Victory.Domain.Features.API.Foods;

public sealed record class GetFoodListByNameQuery : IRequest<List<FoodEntity>?>
{
    public string? Name { get; }

    public GetFoodListByNameQuery(string name) => Name = name;

    public GetFoodListByNameQuery() { }
}