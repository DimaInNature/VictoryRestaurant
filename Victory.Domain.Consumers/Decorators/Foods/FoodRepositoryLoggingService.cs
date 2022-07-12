namespace Victory.Domain.Consumers.Decorators.Foods;

public class FoodRepositoryLoggingService : IFoodRepositoryService
{
    private readonly IFoodRepositoryService _repository;

    private readonly ILogger<FoodRepositoryLoggingService> _logger;

    public FoodRepositoryLoggingService(IFoodRepositoryService repository,
        ILogger<FoodRepositoryLoggingService> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<List<Food>> GetFoodListAsync()
    {
        List<Food> result = new();

        try
        {
            result = await _repository.GetFoodListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<List<Food>> GetFoodListAsync(FoodType type)
    {
        try
        {
            return await _repository.GetFoodListAsync(type);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return new List<Food>()
            {
                new()
                {
                    Name = "Error",
                    Description = "Error",
                    CostInUSD = 0,
                    ImagePath = "https://localhost:7129/img/error_food.jpg"
                }
            };
        }
    }

    public async Task CreateAsync(Food entity, string token)
    {
        try
        {
            await _repository.CreateAsync(entity, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public async Task UpdateAsync(Food entity, string token)
    {
        try
        {
            await _repository.UpdateAsync(entity, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public async Task DeleteAsync(int id, string token)
    {
        try
        {
            await _repository.DeleteAsync(id, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}