namespace Victory.Microservices.FoodService.Domain.Queries.FoodTypes;

public sealed record class GetFoodTypeListByPredicateQuery
    : IRequest<IEnumerable<FoodTypeEntity>>
{
    public Func<FoodTypeEntity, bool>? Predicate { get; }

    public GetFoodTypeListByPredicateQuery(
        Func<FoodTypeEntity, bool> predicate) =>
        Predicate = predicate;

    public GetFoodTypeListByPredicateQuery() { }
}