namespace VictoryRestaurant.Web.Services.Foods;

public class FoodFacadeService : IFoodFacadeService
{
    private readonly IFoodRepositoryService _repositoryService;

    public FoodFacadeService(IFoodRepositoryService repositoryService)
    {
        _repositoryService = repositoryService;
    }

    public void AddFood(Food food)
    {
        _repositoryService.AddFood(food);
    }

    public void ChangeFood(Food food)
    {
        _repositoryService.UpdateFood(food);
    }

    public void DeleteFood(Food food)
    {
        _repositoryService.DeleteFood(food);
    }

    public IEnumerable<Food> GetAllFoods() =>
        _repositoryService.GetAll() ?? new List<Food>();

    public IEnumerable<Food> GetAllFoods(Func<Food, bool> predicate) =>
        _repositoryService.GetAll()
        .AsParallel()
        .Where(predicate)
        .ToList() ?? new List<Food>();

    public Food GetFirstFood(Func<Food, bool> predicate) =>
        _repositoryService.GetAll()
        .AsParallel()
        .Where(predicate)
        .FirstOrDefault() ?? new Food();

    public Food GetFirstFood() =>
        _repositoryService.GetAll()
        .FirstOrDefault() ?? new Food();
}
