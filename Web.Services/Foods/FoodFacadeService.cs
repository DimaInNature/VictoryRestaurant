namespace VictoryRestaurant.Web.Services.Foods;

public class FoodFacadeService : IFoodFacadeService
{
    private readonly IFoodRepositoryService _repositoryService;

    public FoodFacadeService(IFoodRepositoryService repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public async Task<IEnumerable<Food>> GetAllByFoodType(FoodType type) =>
        await _repositoryService.GetAllByFoodType(type);

    public async Task<Food> GetFoodByFootType(FoodType type) =>
        await _repositoryService.GetFoodByFootType(type);
}
