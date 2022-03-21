namespace Desktop.Services.Abstract.Foods;

public interface IFoodRepositoryService
{
    Task<List<Food>> GetFoodsAsync();
    Task<List<Food>> GetAllByFoodType(FoodType type);
    Task<Food?> GetFoodByFootType(FoodType type);
}