namespace Victory.Microservices.FoodService.Domain.Queries.Foods;

public sealed record class GetFoodByPredicateQuery : IRequest<FoodEntity?>
{
    public Func<FoodEntity, bool>? Predicate { get; }

    public GetFoodByPredicateQuery(
        Func<FoodEntity, bool> predicate) =>
        Predicate = predicate;

    public GetFoodByPredicateQuery() { }
}