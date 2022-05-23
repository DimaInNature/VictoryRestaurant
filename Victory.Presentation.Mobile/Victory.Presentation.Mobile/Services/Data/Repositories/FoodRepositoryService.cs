namespace Victory.Presentation.Mobile.Services.Data.Repositories;

public sealed class FoodRepositoryService : IFoodRepositoryService, IService
{
    private readonly IMediator _mediator;

    public FoodRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<Food>> GetFoodListAsync() =>
        await _mediator.Send(request: new GetFoodListQuery()) ?? new();
}