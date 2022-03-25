namespace API.Services.Users;

public class UserFacadeService : IUserFacadeService
{
    private readonly IUserRepositoryService _repository;
    private readonly ICacheService<UserEntity> _cache;

    public UserFacadeService(ICacheService<UserEntity> cache,
        IUserRepositoryService repository)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<List<UserEntity>> GetUserListAsync() =>
        await _repository.GetUserListAsync();

    public async Task<UserEntity> GetUserAsync(string login)
    {
        var user = await _repository.GetUserAsync(login);

        //return _cache.Set(key: user.Id, value: user);
        return user;
    }

    public async Task<UserEntity> GetUserAsync(string login, string password)
    {
        var user = await _repository.GetUserAsync(login, password);

        if (user is null) return null;

        return _cache.Set(key: user.Id, value: user);
    }

    public async Task<UserEntity> GetUserAsync(int userId)
    {
        if (_cache.TryGet(userId, out var user))
            return user;
        else
        {
            user = await _repository.GetUserAsync(userId);

            return _cache.Set(key: userId, value: user);
        }
    }

    public async Task CreateAsync(UserEntity user)
    {
        await _repository.CreateAsync(user);

        _cache.Set(key: user.Id, value: user);
    }

    public async Task UpdateAsync(UserEntity user)
    {
        await _repository.UpdateAsync(user);

        _cache.Set(key: user.Id, value: user);
    }

    public async Task DeleteAsync(int userId)
    {
        await _repository.DeleteAsync(userId);

        if (_cache.TryGet(key: userId, out _))
            _cache.Remove(key: userId);
    }
}