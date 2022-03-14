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

    public async Task<List<UserEntity>> GetUsersAsync() =>
        await _repository.GetUsersAsync();

    public async Task<UserEntity> GetUserAsync(UserEntity user)
    {
        if (_cache.TryGet(user.Id, out user))
            return user;
        else
        {
            user = await _repository.GetUserAsync(user);

            return _cache.Set(key: user.Id, value: user);
        }
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

    public async Task InsertUserAsync(UserEntity user)
    {
        await _repository.InsertUserAsync(user);

        _cache.Set(key: user.Id, value: user);
    }

    public async Task UpdateUserAsync(UserEntity user)
    {
        await _repository.UpdateUserAsync(user);

        _cache.Set(key: user.Id, value: user);
    }

    public async Task DeleteUserAsync(int userId)
    {
        await _repository.DeleteUserAsync(userId);

        if (_cache.TryGet(key: userId, out _))
            _cache.Remove(key: userId);
    }

    public async Task<int> SaveAsync() => await _repository.SaveAsync();
}