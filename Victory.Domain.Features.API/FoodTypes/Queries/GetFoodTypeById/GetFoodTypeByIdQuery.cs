namespace Victory.Domain.Features.API.FoodTypes;

public sealed record class GetFoodTypeByIdQuery : IRequest<FoodTypeEntity?>
{
    public int Id { get; }

    public GetFoodTypeByIdQuery(int id) => Id = id;

    public GetFoodTypeByIdQuery() { }
}