namespace API.Services.Foods;

public class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IMediator _mediator;

    public FoodRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<FoodEntity>?> GetFoodListAsync() =>
        await _mediator.Send(request: new GetFoodListQuery());

    public async Task<FoodEntity?> GetFoodAsync(int foodId) =>
       await _mediator.Send(request: new GetFoodByIdQuery(id: foodId));

    public async Task<List<FoodEntity>?> GetFoodListAsync(string name) =>
        await _mediator.Send(request: new GetFoodListByNameQuery(name: name));

    public async Task<List<FoodEntity>?> GetFoodListAsync(FoodType type) =>
        await _mediator.Send(request: new GetFoodListByTypeQuery(type: type));

    public async Task<FoodEntity?> GetFoodAsync(FoodType type) =>
        await _mediator.Send(request: new GetFoodByTypeQuery(type: type));

    public async Task CreateAsync(FoodEntity food) =>
        await _mediator.Send(request: new CreateFoodCommand(food: food));

    public async Task UpdateAsync(FoodEntity food) =>
        await _mediator.Send(request: new UpdateFoodCommand(food: food));

    public async Task DeleteAsync(int foodId) =>
        await _mediator.Send(request: new DeleteFoodCommand(id: foodId));
}