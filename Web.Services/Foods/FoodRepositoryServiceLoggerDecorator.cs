namespace Web.Services.Foods;

public class FoodRepositoryServiceLoggerDecorator
{
    private readonly IFoodRepositoryService _repositoryService;
    private readonly ILogger<FoodRepositoryServiceLoggerDecorator> _logger;

    public FoodRepositoryServiceLoggerDecorator(IFoodRepositoryService repositoryService,
        ILogger<FoodRepositoryServiceLoggerDecorator> logger)
    {
        _repositoryService = repositoryService;
        _logger = logger;
    }

    public async Task<IEnumerable<Food>> GetAllByFoodTypeAsync(FoodType type)
    {
        try
        {
            return await _repositoryService.GetAllByFoodTypeAsync(type);
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

    public async Task<Food> GetFoodByFootTypeAsync(FoodType type)
    {
        try
        {
            return await _repositoryService.GetFoodByFootTypeAsync(type);
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
