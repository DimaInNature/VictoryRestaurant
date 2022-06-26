﻿namespace Victory.Application.Web.Data.Foods;

public class FoodRepositoryServiceLoggerDecorator
{
    private readonly IFoodRepositoryService _repository;

    private readonly ILogger<FoodRepositoryServiceLoggerDecorator> _logger;

    public FoodRepositoryServiceLoggerDecorator(IFoodRepositoryService repository,
        ILogger<FoodRepositoryServiceLoggerDecorator> logger) =>
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
                    Name = "Ошибка",
                    Description = "Ошибка",
                    CostInUSD = 0,
                    ImagePath = "https://localhost:7129/img/error_food.jpg"
                }
            };
        }
    }

    public async Task CreateAsync(Food entity)
    {
        try
        {
            await _repository.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public async Task UpdateAsync(Food entity)
    {
        try
        {
            await _repository.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            await _repository.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }
}