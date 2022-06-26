namespace Victory.Application.General.Client.Services.Data.FoodTypes;

public class FoodTypeRepositoryService : IFoodTypeRepositoryService
{
    private readonly IMediator _mediator;

    public FoodTypeRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<FoodType?> GetFoodTypeAsync(int id) =>
        await _mediator.Send(request: new GetFoodTypeByIdQuery());

    public async Task<List<FoodType>?> GetFoodTypeListAsync() =>
        await _mediator.Send(request: new GetFoodTypeListQuery());
}