namespace Victory.Microservices.FoodService.Domain.Queries.Foods;

public sealed record class GetFoodListQueryHandler
    : IRequestHandler<GetFoodListQuery, IEnumerable<FoodEntity>>
{
    private readonly IGenericRepository<FoodEntity> _repository;

    public GetFoodListQueryHandler(
        IGenericRepository<FoodEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<FoodEntity>> Handle(
        GetFoodListQuery request,
        CancellationToken token) =>
        _repository.GetAll() ?? new List<FoodEntity>();
}