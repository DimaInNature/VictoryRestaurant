namespace Victory.Application.General.Client.Features.FoodTypes;

public sealed record class GetFoodTypeByIdQuery : IRequest<FoodType?>
{
    public int Id { get; }

    public GetFoodTypeByIdQuery(int id) => Id = id;

    public GetFoodTypeByIdQuery() { }
}