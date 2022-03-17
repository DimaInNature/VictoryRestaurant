namespace Web.Services.Users;

public class UserRepositoryServiceLoggerDecorator
{
    private readonly IUserRepositoryService _repositoryService;
    private readonly ILogger<UserRepositoryServiceLoggerDecorator> _logger;

    public UserRepositoryServiceLoggerDecorator(IUserRepositoryService repositoryService,
        ILogger<UserRepositoryServiceLoggerDecorator> logger)
    {
        _repositoryService = repositoryService;
        _logger = logger;
    }

    public async Task InsertUserAsync(User user)
    {
        try
        {
            await _repositoryService.InsertUserAsync(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public async Task<User> GetUserAsync(string login)
    {
        try
        {
            return await _repositoryService.GetUserAsync(login);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return null;
        }
    }

    public async Task<User> GetUserAsync(string login, string password)
    {
        try
        {
            return await _repositoryService.GetUserAsync(login, password);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return null;
        }
    }
}