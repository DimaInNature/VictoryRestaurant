namespace Victory.Application.Api.Interfaces.Data.Foods;

public interface IFoodFacadeService
{
    Task<List<FoodEntity>> GetFoodListAsync();
    Task<List<FoodEntity>> GetFoodListAsync(string name);
    Task<List<FoodEntity>> GetFoodListAsync(FoodType type);
    Task<FoodEntity?> GetFoodAsync(int id);
    Task<FoodEntity?> GetFoodAsync(FoodType type);
    Task CreateAsync(FoodEntity entity);
    Task UpdateAsync(FoodEntity entity);
    Task DeleteAsync(int id);
}