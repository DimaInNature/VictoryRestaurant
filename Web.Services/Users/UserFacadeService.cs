namespace Web.Services.Users;

public class UserFacadeService : IUserFacadeService
{
    private readonly UserRepositoryServiceLoggerDecorator _repository;
    private readonly ICacheService<User> _cache;

    public UserFacadeService(ICacheService<User> cache,
        UserRepositoryServiceLoggerDecorator repository)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<User> GetUserAsync(string login)
    {
        var user = await _repository.GetUserAsync(login);

        _cache.Set(key: user.Id, value: user);

        return user;
    }

    public async Task<User> GetUserAsync(string login, string password)
    {
        var user = await _repository.GetUserAsync(login, password);

        //_cache.Set(key: user.Id, value: user);

        return user;
    }

    public async Task InsertUserAsync(User user)
    {
        await _repository.InsertUserAsync(user);

        _cache.Set(key: user.Id, value: user);
    }
}