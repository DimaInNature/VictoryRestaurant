namespace Victory.Application.Web.Data.Tables;

public class TableRepositoryServiceLoggerDecorator
{
    private readonly ITableRepositoryService _repository;

    private readonly ILogger<TableRepositoryServiceLoggerDecorator> _logger;

    public TableRepositoryServiceLoggerDecorator(ITableRepositoryService repository,
        ILogger<TableRepositoryServiceLoggerDecorator> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task<List<Table>> GetTableListAsync()
    {
        List<Table> result = new();

        try
        {
            result = await _repository.GetTableListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<List<Table>> GetTableListAsync(int number)
    {
        List<Table> result = new();

        try
        {
            result = await _repository.GetTableListAsync(number);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<List<Table>> GetTableListAsync(string status)
    {
        List<Table> result = new();

        try
        {
            result = await _repository.GetTableListAsync(status);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return result;
    }

    public async Task<Table?> GetTableAsync(int id, string token)
    {
        try
        {
            return await _repository.GetTableAsync(id, token);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return null;
        }
    }

    public async Task CreateAsync(Table entity, string token)
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

    public async Task UpdateAsync(Table entity)
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