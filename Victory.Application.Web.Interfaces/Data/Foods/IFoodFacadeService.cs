namespace Victory.Application.Web.Interfaces.Data.Foods;

public interface IFoodFacadeService
{
    Task<List<Food>> GetFoodListAsync();
    Task<List<Food>> GetFoodListAsync(FoodType type);
    Task CreateAsync(Food entity);
    Task UpdateAsync(Food entity);
    Task DeleteAsync(int id);
}