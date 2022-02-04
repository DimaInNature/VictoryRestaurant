using API.Data.Repositories.Abstract;
using API.Services.Abstract.Repositories;
using VictoryRestaurant.API;
using VictoryRestaurant.API.Entities;

namespace API.Services.Repositories;

public class FoodRepositoryService : IFoodRepositoryService
{
    private readonly IFoodRepository _repository;

    public FoodRepositoryService(IFoodRepository repository)
    {
        _repository = repository;
    }

    public async Task DeleteFoodAsync(int foodId) =>
        await _repository.DeleteFoodAsync(foodId);

    public async Task<FoodEntity> GetFoodAsync(int foodId) =>
        await _repository.GetFoodAsync(foodId);

    public async Task<FoodEntity> GetFoodByFootTypeAsync(FoodType type) =>
        await _repository.GetFoodByFootTypeAsync(type);

    public async Task<List<FoodEntity>> GetFoodsAsync() =>
        await _repository.GetFoodsAsync();

    public async Task<List<FoodEntity>> GetFoodsAsync(string name) =>
        await _repository.GetFoodsAsync(name);

    public async Task<List<FoodEntity>> GetFoodsAsync(FoodType type) =>
        await _repository.GetFoodsAsync(type);

    public async Task InsertFoodAsync(FoodEntity food) =>
        await _repository.InsertFoodAsync(food);

    public async Task UpdateFoodAsync(FoodEntity food) =>
        await _repository.UpdateFoodAsync(food);

    public async Task SaveAsync() =>
        await _repository.SaveAsync();
}
