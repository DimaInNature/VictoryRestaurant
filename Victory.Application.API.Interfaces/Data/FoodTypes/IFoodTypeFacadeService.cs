namespace Victory.Application.API.Interfaces.Data.FoodTypes;

public interface IFoodTypeFacadeService
{
    Task<List<FoodTypeEntity>?> GetFoodTypeListAsync();
    Task<List<FoodTypeEntity>?> GetFoodTypeListAsync(string name);
    Task<FoodTypeEntity?> GetFoodTypeAsync(int id);
    Task CreateAsync(FoodTypeEntity entity);
    Task UpdateAsync(FoodTypeEntity entity);
    Task DeleteAsync(int id);
}