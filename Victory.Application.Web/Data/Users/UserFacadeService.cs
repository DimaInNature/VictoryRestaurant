namespace Victory.Application.Web.Data.Users;

public class UserFacadeService : IUserFacadeService
{
    private readonly UserRepositoryServiceLoggerDecorator _repository;

    private readonly ICacheService<User> _cache;

    public UserFacadeService(ICacheService<User> cache,
        UserRepositoryServiceLoggerDecorator repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<User>> GetUserListAsync(string token) =>
        await _repository.GetUserListAsync(token);

    public async Task<User?> GetUserAsync(string login, string token)
    {
        var entity = await _repository.GetUserAsync(login, token);

        if (entity is null) return null;

        _cache.Set(key: entity.Id, value: entity);

        return entity;
    }

    public async Task<User?> GetUserAsync(UserLogin userLogin)
    {
        var entity = await _repository.GetUserAsync(userLogin);

        if (entity is null) return null;

        _cache.Set(key: entity.Id, value: entity);

        return entity;
    }

    public async Task<User?> CreateAsync(User entity)
    {
        if (entity is null) return null;

        await _repository.CreateAsync(entity);

        return _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(User entity, string token)
    {
        await _repository.UpdateAsync(entity, token);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id, string token)
    {
        await _repository.DeleteAsync(id, token);

        if (_cache.TryGet(key: id, out _))
            _cache.Remove(key: id);
    }
}