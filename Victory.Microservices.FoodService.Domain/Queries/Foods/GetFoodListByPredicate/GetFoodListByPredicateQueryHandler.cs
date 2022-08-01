namespace Victory.Microservices.FoodService.Domain.Queries.Foods;

public sealed record class GetFoodListByPredicateQueryHandler
    : IRequestHandler<GetFoodListByPredicateQuery, IEnumerable<FoodEntity>>
{
    private readonly IGenericRepository<FoodEntity> _repository;

    public GetFoodListByPredicateQueryHandler(
        IGenericRepository<FoodEntity> repository) => _repository = repository;

    public async Task<IEnumerable<FoodEntity>> Handle(
        GetFoodListByPredicateQuery request,
        CancellationToken token) => 
        request.Predicate is null
        ? new List<FoodEntity>()
        : _repository.GetAll(
            user => request.Predicate(user)) ?? new List<FoodEntity>();
}