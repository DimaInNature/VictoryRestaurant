namespace Victory.Microservices.FoodService.Domain.Queries.FoodTypes;

public sealed record class GetFoodTypeListQueryHandler
    : IRequestHandler<GetFoodTypeListQuery, IEnumerable<FoodTypeEntity>>
{
    private readonly IGenericRepository<FoodTypeEntity> _repository;

    public GetFoodTypeListQueryHandler(
        IGenericRepository<FoodTypeEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<FoodTypeEntity>> Handle(
        GetFoodTypeListQuery request,
        CancellationToken token) =>
        _repository.GetAll() ?? new List<FoodTypeEntity>();
}