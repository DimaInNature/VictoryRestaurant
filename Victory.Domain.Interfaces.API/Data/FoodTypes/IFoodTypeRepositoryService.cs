namespace Victory.Domain.Interfaces.API.Data.FoodTypes;

public interface IFoodTypeRepositoryService
{
    Task<List<FoodTypeEntity>?> GetFoodTypeListAsync();
    Task<List<FoodTypeEntity>?> GetFoodTypeListAsync(string name);
    Task<FoodTypeEntity?> GetFoodTypeAsync(int id);
    Task CreateAsync(FoodTypeEntity entity);
    Task UpdateAsync(FoodTypeEntity entity);
    Task DeleteAsync(int id);
}