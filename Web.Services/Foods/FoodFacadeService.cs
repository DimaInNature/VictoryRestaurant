namespace VictoryRestaurant.Web.Services.Foods;

public class FoodFacadeService : IFoodFacadeService
{
    private readonly FoodRepositoryServiceLoggerDecorator _repositoryService;

    public FoodFacadeService(FoodRepositoryServiceLoggerDecorator repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task<IEnumerable<Food>> GetAllByFoodTypeAsync(FoodType type) =>
        await _repositoryService.GetAllByFoodTypeAsync(type);

    public async Task<Food> GetFoodByFootTypeAsync(FoodType type) =>
        await _repositoryService.GetFoodByFootTypeAsync(type);
}
