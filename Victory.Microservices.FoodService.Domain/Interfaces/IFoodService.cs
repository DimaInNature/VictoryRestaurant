namespace Victory.Microservices.FoodService.Domain.Interfaces;

public interface IFoodService
{
    Task<IEnumerable<FoodEntity>> GetAllAsync();

    Task<IEnumerable<FoodEntity>> GetAllAsync(Func<FoodEntity, bool> predicate);

    Task<FoodEntity?> GetAsync(int id);

    Task<FoodEntity?> GetAsync(Func<FoodEntity, bool> predicate);

    Task CreateAsync(FoodEntity entity);

    Task UpdateAsync(FoodEntity entity);

    Task DeleteAsync(int id);
}