namespace API.Services.Abstract.Foods;

public interface IFoodFacadeService
{
    Task<List<FoodEntity>> GetFoodsAsync();
    Task<List<FoodEntity>> GetFoodsAsync(string name);
    Task<List<FoodEntity>> GetFoodsAsync(FoodType type);
    Task<FoodEntity> GetFoodAsync(int foodId);
    Task<FoodEntity> GetFoodByFootTypeAsync(FoodType type);
    Task InsertFoodAsync(FoodEntity food);
    Task UpdateFoodAsync(FoodEntity food);
    Task DeleteFoodAsync(int foodId);
    Task<int> SaveAsync();
}