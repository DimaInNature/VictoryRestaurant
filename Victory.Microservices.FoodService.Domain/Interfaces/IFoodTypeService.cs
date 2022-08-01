namespace Victory.Microservices.FoodService.Domain.Interfaces;

public interface IFoodTypeService
{
    Task<IEnumerable<FoodTypeEntity>> GetAllAsync();

    Task<IEnumerable<FoodTypeEntity>> GetAllAsync(Func<FoodTypeEntity, bool> predicate);

    Task<FoodTypeEntity?> GetAsync(int id);

    Task<FoodTypeEntity?> GetAsync(Func<FoodTypeEntity, bool> predicate);

    Task CreateAsync(FoodTypeEntity entity);

    Task UpdateAsync(FoodTypeEntity entity);

    Task DeleteAsync(int id);
}