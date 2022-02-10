namespace Desktop.Services.Abstract.Repositories;

public interface IFoodRepositoryService
{
    Task<List<Food>> GetFoodsAsync();
    Task<IEnumerable<Food>> GetAllByFoodType(FoodType type);
    Task<Food> GetFoodByFootType(FoodType type);
}
