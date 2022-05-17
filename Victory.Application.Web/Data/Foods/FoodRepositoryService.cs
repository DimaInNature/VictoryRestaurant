namespace Victory.Application.Web.Data.Foods;

public class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IMediator _mediator;

    public FoodRepositoryService(IMediator mediator) => _mediator = mediator;

    public async Task<List<Food>?> GetFoodListAsync(FoodType type) =>
        await _mediator.Send(request: new GetFoodListByFoodTypeQuery(type));

    public async Task<Food> GetFoodAsync(FoodType type) =>
        await _mediator.Send(request: new GetFoodByFoodTypeQuery(type));
}