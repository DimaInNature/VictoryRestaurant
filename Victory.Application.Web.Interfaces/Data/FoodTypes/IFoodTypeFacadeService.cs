namespace Victory.Application.Web.Interfaces.Data.FoodTypes;

public interface IFoodTypeFacadeService
{
    Task<List<FoodType>> GetFoodTypeListAsync();
    Task<FoodType?> GetFoodTypeAsync(int id);
}