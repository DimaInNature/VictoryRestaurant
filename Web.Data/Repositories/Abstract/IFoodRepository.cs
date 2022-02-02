namespace VictoryRestaurant.Web.Data.Repositories.Abstract;

public interface IFoodRepository
{
    Task AddFoodAsync(FoodEntity foodItem);
    Task UpdateFood(FoodEntity foodItem);
    Task DeleteFood(FoodEntity foodItem);
    Task<FoodEntity> GetFoodById(int id);
    IEnumerable<FoodEntity> GetAll();
}