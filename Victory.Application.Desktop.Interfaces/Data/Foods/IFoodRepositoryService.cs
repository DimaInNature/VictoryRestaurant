namespace Victory.Application.Desktop.Interfaces.Data.Bookings;

public interface IFoodRepositoryService
{
    Task<List<Food>> GetFoodListAsync();
    Task<List<Food>> GetFoodListAsync(FoodType type);
    Task<Food?> GetFoodAsync(FoodType type);
    Task CreateAsync(Food food);
    Task UpdateAsync(Food food);
    Task DeleteAsync(int id);
}