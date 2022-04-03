namespace Victory.Application.Desktop.Interfaces;

public interface IFoodFacadeService
{
    Task<List<Food>> GetFoodListAsync();
    Task<List<Food>> GetFoodListAsync(FoodType type);
    Task<Food?> GetFoodAsync(FoodType type);
    Task CreateAsync(Food entity);
    Task UpdateAsync(Food entity);
    Task DeleteAsync(int id);
}