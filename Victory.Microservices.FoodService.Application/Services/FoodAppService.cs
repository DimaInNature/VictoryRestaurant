namespace Victory.Microservices.FoodService.Application.Services;

public class FoodAppService : IFoodAppService
{
    private readonly IMediator _mediator;

	public FoodAppService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<FoodEntity>> GetAllAsync() =>
        await _mediator.Send(request: new GetFoodListQuery());

    public async Task<IEnumerable<FoodEntity>> GetAllAsync(
        Func<FoodEntity, bool> predicate) =>
        await _mediator.Send(request: new GetFoodListByPredicateQuery(predicate));

    public async Task<FoodEntity?> GetAsync(int id) =>
        await _mediator.Send(
            request: new GetFoodByPredicateQuery(
                predicate: entity => entity.Id == id));

    public async Task<FoodEntity?> GetAsync(
        Func<FoodEntity, bool> predicate) =>
        await _mediator.Send(request: new GetFoodByPredicateQuery(predicate));

    public async Task CreateAsync(FoodEntity entity) =>
        await _mediator.Send(request: new CreateFoodCommand(entity));

    public async Task UpdateAsync(FoodEntity entity) =>
        await _mediator.Send(request: new UpdateFoodCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteFoodCommand(id));
}