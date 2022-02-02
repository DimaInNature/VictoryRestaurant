namespace VictoryRestaurant.Web.Services.Foods;

public class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IFoodRepository _repository;

    public FoodRepositoryService(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async void AddFood(Food foodItem)
    {
        await _repository.AddFoodAsync(foodItem.ToEntity());
    }

    public async void DeleteFood(Food foodItem)
    {
        await _repository.DeleteFood(foodItem.ToEntity());
    }

    public IEnumerable<Food> GetAll() =>
        new List<Food>()
        .Concat(_repository.GetAll()
            .Select(x => x.ToDomain()));

    public Food GetFoodById(int id)
    {
        return _repository.GetFoodById(id).Result.ToDomain();
    }

    public void UpdateFood(Food foodItem)
    {
        _repository.UpdateFood(foodItem.ToEntity());
    }
}