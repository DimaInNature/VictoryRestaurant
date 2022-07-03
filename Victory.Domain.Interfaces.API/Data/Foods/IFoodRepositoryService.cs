namespace Victory.Domain.Interfaces.API.Data.Foods;

public interface IFoodRepositoryService
{
    Task<List<FoodEntity>?> GetFoodListAsync();
    Task<List<FoodEntity>?> GetFoodListAsync(string name);
    Task<List<FoodEntity>?> GetFoodListByTypeAsync(string type);
    Task<FoodEntity?> GetFoodAsync(int id);
    Task<FoodEntity?> GetFoodAsync(string type);
    Task CreateAsync(FoodEntity entity);
    Task UpdateAsync(FoodEntity entity);
    Task DeleteAsync(int id);
}