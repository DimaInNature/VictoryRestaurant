namespace Victory.Microservices.FoodService.Domain.Queries.FoodTypes;

public sealed record class GetFoodTypeListByPredicateQueryHandler
    : IRequestHandler<GetFoodTypeListByPredicateQuery, IEnumerable<FoodTypeEntity>>
{
    private readonly IGenericRepository<FoodTypeEntity> _repository;

    public GetFoodTypeListByPredicateQueryHandler(
        IGenericRepository<FoodTypeEntity> repository) => _repository = repository;

    public async Task<IEnumerable<FoodTypeEntity>> Handle(
        GetFoodTypeListByPredicateQuery request,
        CancellationToken token) =>
        request.Predicate is null
        ? new List<FoodTypeEntity>()
        : _repository.GetAll(
            user => request.Predicate(user)) ?? new List<FoodTypeEntity>();
}