namespace Victory.Consumers.Web.Application.Services.Foods;

public class FoodLoggingService : IFoodService
{
    private readonly IFoodService _repository;

    private readonly ILogger<FoodLoggingService> _logger;

    public FoodLoggingService(
        IFoodService repository,
        ILogger<FoodLoggingService> logger) =>
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
}