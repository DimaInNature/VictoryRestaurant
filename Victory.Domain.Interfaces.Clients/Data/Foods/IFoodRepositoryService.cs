namespace Victory.Domain.Interfaces.Clients.Data.Foods;

public interface IFoodRepositoryService
{
    Task<List<Food>> GetFoodListAsync();
    Task<List<Food>> GetFoodListAsync(FoodType type);
    Task CreateAsync(Food food);
    Task UpdateAsync(Food food);
    Task DeleteAsync(int id);
}