namespace Victory.Application.Services;

public class UserFacadeService : IUserFacadeService
{
    private readonly IUserRepositoryService _repository;
    private readonly ICacheService<UserEntity> _cache;

    public UserFacadeService(ICacheService<UserEntity> cache,
        IUserRepositoryService repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<UserEntity>> GetUserListAsync() =>
        await _repository.GetUserListAsync() ?? new();

    public async Task<UserEntity?> GetUserAsync(string login)
    {
        var entity = await _repository.GetUserAsync(login);

        return entity is null ? null : _cache.Set(key: entity.Id, value: entity);
    }

    public async Task<UserEntity?> GetUserAsync(string login, string password)
    {
        var entity = await _repository.GetUserAsync(login, password);

        return entity is null ? null : _cache.Set(key: entity.Id, value: entity);
    }

    public async Task<UserEntity?> GetUserAsync(int id)
    {
        if (_cache.TryGet(id, out var entity)) return entity;

        entity = await _repository.GetUserAsync(id);

        return entity is null ? null : _cache.Set(key: id, value: entity);
    }

    public async Task CreateAsync(UserEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(UserEntity entity)
    {
        if (entity is null) return;

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