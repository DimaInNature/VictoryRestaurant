namespace Victory.Consumers.Web.Application.Services.Foods;

public class FoodService : IFoodService
{
    private readonly IMediator _mediator;

    public FoodService(IMediator mediator) =>
        _mediator = mediator;

    public async Task<List<Food>> GetFoodListAsync() =>
        await _mediator.Send(request: new GetFoodListQuery()) ?? new();

    public async Task<List<Food>> GetFoodListAsync(FoodType type) =>
        await _mediator.Send(request: new GetFoodListByFoodTypeQuery(type)) ?? new();
}