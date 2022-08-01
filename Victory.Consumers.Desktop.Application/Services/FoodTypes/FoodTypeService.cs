namespace Victory.Consumers.Desktop.Application.Services.FoodTypes;

public class FoodTypeService : IFoodTypeService
{
    private readonly IMediator _mediator;

    public FoodTypeService(IMediator mediator) => _mediator = mediator;

    public async Task<FoodType?> GetFoodTypeAsync(int id, string token) =>
        await _mediator.Send(request: new GetFoodTypeByIdQuery(id, token));

    public async Task<List<FoodType>?> GetFoodTypeListAsync() =>
        await _mediator.Send(request: new GetFoodTypeListQuery());
}