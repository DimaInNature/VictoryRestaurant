namespace Victory.Application.Web.Services;

public class UserRepositoryServiceLoggerDecorator
{
    private readonly IUserRepositoryService _repository;
    private readonly ILogger<UserRepositoryServiceLoggerDecorator> _logger;

    public UserRepositoryServiceLoggerDecorator(IUserRepositoryService repository,
        ILogger<UserRepositoryServiceLoggerDecorator> logger) =>
        (_repository, _logger) = (repository, logger);

    public async Task CreateAsync(User entity)
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

    public async Task<User?> GetUserAsync(string login)
    {
        try
        {
            return await _repository.GetUserAsync(login);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return null;
        }
    }

    public async Task<User?> GetUserAsync(string login, string password)
    {
        try
        {
            return await _repository.GetUserAsync(login, password);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return null;
        }
    }
}