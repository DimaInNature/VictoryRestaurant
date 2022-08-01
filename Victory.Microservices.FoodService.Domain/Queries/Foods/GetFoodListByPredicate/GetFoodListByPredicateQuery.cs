namespace Victory.Microservices.FoodService.Domain.Queries.Foods;

public sealed record class GetFoodListByPredicateQuery
    : IRequest<IEnumerable<FoodEntity>>
{
    public Func<FoodEntity, bool>? Predicate { get; }

    public GetFoodListByPredicateQuery(
        Func<FoodEntity, bool> predicate) =>
        Predicate = predicate;

    public GetFoodListByPredicateQuery() { }
}