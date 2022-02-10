namespace VictoryRestaurant.Web.Services.Abstract.Foods;

public interface IFoodRepositoryService
{
    Task<IEnumerable<Food>> GetAllByFoodType(FoodType type);
    Task<Food> GetFoodByFootType(FoodType type);
}