namespace Victory.Persistence.Repositories.API.Foods;

public class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IMediator _mediator;

    public FoodRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<FoodEntity>?> GetFoodListAsync() =>
        await _mediator.Send(request: new GetFoodListQuery());

    public async Task<FoodEntity?> GetFoodAsync(int id) =>
       await _mediator.Send(request: new GetFoodByIdQuery(id));

    public async Task<List<FoodEntity>?> GetFoodListAsync(string name) =>
        await _mediator.Send(request: new GetFoodListByNameQuery(name));

    public async Task<List<FoodEntity>?> GetFoodListByTypeAsync(string type) =>
        await _mediator.Send(request: new GetFoodListByTypeQuery(type));

    public async Task<FoodEntity?> GetFoodAsync(string type) =>
        await _mediator.Send(request: new GetFoodByTypeQuery(type));

    public async Task CreateAsync(FoodEntity entity) =>
        await _mediator.Send(request: new CreateFoodCommand(entity));

    public async Task UpdateAsync(FoodEntity entity) =>
        await _mediator.Send(request: new UpdateFoodCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteFoodCommand(id));
}