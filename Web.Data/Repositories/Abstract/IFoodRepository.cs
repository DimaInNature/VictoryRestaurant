namespace VictoryRestaurant.Web.Data.Repositories.Abstract;

public interface IFoodRepository
{
    Task<IEnumerable<FoodEntity>> GetAllByFoodType(FoodType type);
    Task<FoodEntity> GetFoodByFootTypeAsync(FoodType type);
}