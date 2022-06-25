namespace Victory.Application.API.Features.FoodTypes;

public sealed record class GetFoodTypeListByNameQuery : IRequest<List<FoodTypeEntity>?>
{
    public string? Name { get; }

    public GetFoodTypeListByNameQuery(string name) => Name = name;

    public GetFoodTypeListByNameQuery() { }
}