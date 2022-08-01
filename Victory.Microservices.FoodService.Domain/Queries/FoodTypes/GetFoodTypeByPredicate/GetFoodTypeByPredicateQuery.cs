namespace Victory.Microservices.FoodService.Domain.Queries.FoodTypes;

public sealed record class GetFoodTypeByPredicateQuery : IRequest<FoodTypeEntity?>
{
    public Func<FoodTypeEntity, bool>? Predicate { get; }

    public GetFoodTypeByPredicateQuery(
        Func<FoodTypeEntity, bool> predicate) =>
        Predicate = predicate;

    public GetFoodTypeByPredicateQuery() { }
}