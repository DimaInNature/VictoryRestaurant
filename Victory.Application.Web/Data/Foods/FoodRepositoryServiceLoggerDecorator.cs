namespace Victory.Application.Web.Data.Foods;

public class FoodRepositoryServiceLoggerDecorator
{
    private readonly IFoodRepositoryService _repository;
    private readonly ILogger<FoodRepositoryServiceLoggerDecorator> _logger;

    public FoodRepositoryServiceLoggerDecorator(IFoodRepositoryService repository,
        ILogger<FoodRepositoryServiceLoggerDecorator> logger) =>
        (_repository, _logger) = (repository, logger);

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
                    Name = "Ошибка",
                    Description = "Ошибка",
                    CostInUSD = 0,
                    ImagePath = "https://localhost:7129/img/error_food.jpg"
                }
            };
        }
    }

    public async Task<Food> GetFoodAsync(FoodType type)
    {
        try
        {
            return await _repository.GetFoodAsync(type);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return new()
            {
                Name = "Ошибка",
                Description = "Ошибка",
                CostInUSD = 0,
                ImagePath = "https://localhost:7129/img/error_food.jpg"
            };
        }
    }
}