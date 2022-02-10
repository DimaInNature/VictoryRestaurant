namespace Desktop.Data.Repositories.Abstract;

public interface IFoodRepository : IDisposable
{
    Task<List<Food>> GetFoodsAsync();
    Task<IEnumerable<Food>> GetAllByFoodType(FoodType type);
    Task<Food> GetFoodByFootType(FoodType type);
}
