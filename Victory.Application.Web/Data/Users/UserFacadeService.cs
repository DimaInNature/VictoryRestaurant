namespace Victory.Application.Web.Data.Users;

public class UserFacadeService : IUserFacadeService
{
    private readonly UserRepositoryServiceLoggerDecorator _repository;

    private readonly ICacheService<User> _cache;

    public UserFacadeService(ICacheService<User> cache,
        UserRepositoryServiceLoggerDecorator repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<User>> GetUserListAsync() =>
        await _repository.GetUserListAsync();

    public async Task<User?> GetUserAsync(string login)
    {
        var entity = await _repository.GetUserAsync(login);

        if (entity is null) return null;

        _cache.Set(key: entity.Id, value: entity);

        return entity;
    }

    public async Task<User?> GetUserAsync(string login, string password)
    {
        var entity = await _repository.GetUserAsync(login, password);

        if (entity is null) return null;

        _cache.Set(key: entity.Id, value: entity);

        return entity;
    }

    public async Task CreateAsync(User entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(User entity)
    {
        await _repository.UpdateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        if (_cache.TryGet(key: id, out _))
            _cache.Remove(key: id);
    }
}