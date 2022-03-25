namespace API.Services.Abstract.Foods;

public interface IFoodRepositoryService
{
    Task<List<FoodEntity>?> GetFoodListAsync();
    Task<List<FoodEntity>?> GetFoodListAsync(string name);
    Task<List<FoodEntity>?> GetFoodListAsync(FoodType type);
    Task<FoodEntity?> GetFoodAsync(int foodId);
    Task<FoodEntity?> GetFoodAsync(FoodType type);
    Task CreateAsync(FoodEntity food);
    Task UpdateAsync(FoodEntity food);
    Task DeleteAsync(int foodId);
}