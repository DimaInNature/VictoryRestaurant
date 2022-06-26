namespace Victory.Application.General.Client.Services.Data.Foods;

public sealed class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IMediator _mediator;

    public FoodRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<Food>> GetFoodListAsync() =>
        await _mediator.Send(request: new GetFoodListQuery()) ?? new();

    public async Task<List<Food>> GetFoodListAsync(FoodType type) =>
        await _mediator.Send(request: new GetFoodListByFoodTypeQuery(type)) ?? new();

    public async Task CreateAsync(Food entity) =>
        await _mediator.Send(request: new CreateFoodCommand(entity));

    public async Task UpdateAsync(Food entity) =>
        await _mediator.Send(request: new UpdateFoodCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteFoodCommand(id));
}