namespace Victory.Application.CQRS.Clients.FoodTypes;

public sealed record class GetFoodTypeByIdQuery
    : BaseAuthorizedFeature, IRequest<FoodType?>
{
    public int Id { get; }

    public GetFoodTypeByIdQuery(int id, string token) =>
        (Id, Token) = (id, token);

    public GetFoodTypeByIdQuery() { }
}