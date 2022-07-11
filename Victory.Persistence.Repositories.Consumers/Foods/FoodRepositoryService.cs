namespace Victory.Persistence.Repositories.Consumers.Foods;

public sealed class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IMediator _mediator;

    public FoodRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<Food>> GetFoodListAsync() =>
        await _mediator.Send(request: new GetFoodListQuery()) ?? new();

    public async Task<List<Food>> GetFoodListAsync(FoodType type) =>
        await _mediator.Send(request: new GetFoodListByFoodTypeQuery(type)) ?? new();

    public async Task CreateAsync(Food entity, string token) =>
        await _mediator.Send(request: new CreateFoodCommand(entity, token));

    public async Task UpdateAsync(Food entity, string token) =>
        await _mediator.Send(request: new UpdateFoodCommand(entity, token));

    public async Task DeleteAsync(int id, string token) =>
        await _mediator.Send(request: new DeleteFoodCommand(id, token));
}