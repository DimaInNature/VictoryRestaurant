namespace Victory.Microservices.FoodService.Application.Services;

public class FoodTypeAppService : IFoodTypeAppService
{
    private readonly IMediator _mediator;

	public FoodTypeAppService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<IEnumerable<FoodTypeEntity>> GetAllAsync() =>
        await _mediator.Send(request: new GetFoodTypeListQuery());

    public async Task<IEnumerable<FoodTypeEntity>> GetAllAsync(
        Func<FoodTypeEntity, bool> predicate) =>
        await _mediator.Send(request: new GetFoodTypeListByPredicateQuery(predicate));

    public async Task<FoodTypeEntity?> GetAsync(int id) =>
        await _mediator.Send(
            request: new GetFoodTypeByPredicateQuery(
                predicate: entity => entity.Id == id));

    public async Task<FoodTypeEntity?> GetAsync(
        Func<FoodTypeEntity, bool> predicate) =>
        await _mediator.Send(request: new GetFoodTypeByPredicateQuery(predicate));

    public async Task CreateAsync(FoodTypeEntity entity) =>
        await _mediator.Send(request: new CreateFoodTypeCommand(entity));

    public async Task UpdateAsync(FoodTypeEntity entity) =>
        await _mediator.Send(request: new UpdateFoodTypeCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteFoodTypeCommand(id));
}