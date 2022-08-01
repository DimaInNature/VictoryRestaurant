namespace Victory.Microservices.FoodService.Domain.Queries.FoodTypes;

public sealed record class GetFoodTypeByPredicateQueryHandler
    : IRequestHandler<GetFoodTypeByPredicateQuery, FoodTypeEntity?>
{
    private readonly IGenericRepository<FoodTypeEntity> _repository;

    public GetFoodTypeByPredicateQueryHandler(
        IGenericRepository<FoodTypeEntity> repository) =>
        _repository = repository;

    public async Task<FoodTypeEntity?> Handle(
        GetFoodTypeByPredicateQuery request,
        CancellationToken token) =>
        request.Predicate is null
        ? null
        : _repository.GetFirstOrDefault(
            predicate: user => request.Predicate(user));

}