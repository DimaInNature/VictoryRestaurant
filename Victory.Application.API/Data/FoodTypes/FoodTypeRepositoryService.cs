namespace Victory.Application.API.Data.FoodTypes;

public class FoodTypeRepositoryService : IFoodTypeRepositoryService
{
    private readonly IMediator _mediator;

    public FoodTypeRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<FoodTypeEntity>?> GetFoodTypeListAsync() =>
        await _mediator.Send(request: new GetFoodTypeListQuery());

    public async Task<List<FoodTypeEntity>?> GetFoodTypeListAsync(string name) =>
        await _mediator.Send(request: new GetFoodTypeListByNameQuery(name));

    public async Task<FoodTypeEntity?> GetFoodTypeAsync(int id) =>
        await _mediator.Send(request: new GetFoodTypeByIdQuery(id));

    public async Task CreateAsync(FoodTypeEntity entity) =>
        await _mediator.Send(request: new CreateFoodTypeCommand(entity));

    public async Task UpdateAsync(FoodTypeEntity entity) =>
        await _mediator.Send(request: new UpdateFoodTypeCommand(entity));

    public async Task DeleteAsync(int id) =>
        await _mediator.Send(request: new DeleteFoodTypeCommand(id));
}