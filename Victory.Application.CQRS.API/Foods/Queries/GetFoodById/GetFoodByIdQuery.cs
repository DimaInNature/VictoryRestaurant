namespace Victory.Application.CQRS.API.Foods;

public sealed record class GetFoodByIdQuery : IRequest<FoodEntity?>
{
    public int Id { get; }

    public GetFoodByIdQuery(int id) => Id = id;

    public GetFoodByIdQuery() { }
}