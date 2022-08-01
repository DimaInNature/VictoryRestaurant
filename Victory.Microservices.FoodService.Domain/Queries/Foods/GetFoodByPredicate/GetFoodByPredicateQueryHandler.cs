namespace Victory.Microservices.FoodService.Domain.Queries.Foods;

public sealed record class GetFoodByPredicateQueryHandler
    : IRequestHandler<GetFoodByPredicateQuery, FoodEntity?>
{
    private readonly IGenericRepository<FoodEntity> _repository;

    public GetFoodByPredicateQueryHandler(
        IGenericRepository<FoodEntity> repository) =>
        _repository = repository;

    public async Task<FoodEntity?> Handle(
        GetFoodByPredicateQuery request,
        CancellationToken token) =>
        request.Predicate is null
        ? null
        : _repository.GetFirstOrDefault(
            predicate: user => request.Predicate(user));

}