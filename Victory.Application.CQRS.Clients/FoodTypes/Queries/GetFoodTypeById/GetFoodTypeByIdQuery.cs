namespace Victory.Application.CQRS.Clients.FoodTypes;

public sealed record class GetFoodTypeByIdQuery : IRequest<FoodType?>
{
    public int Id { get; }

    public GetFoodTypeByIdQuery(int id) => Id = id;

    public GetFoodTypeByIdQuery() { }
}