namespace Victory.Application.API.Data.UserRoles;

public class UserRoleFacadeService : IUserRoleFacadeService
{
    private readonly IUserRoleRepositoryService _repository;
    private readonly ICacheService<UserRoleEntity> _cache;

    public UserRoleFacadeService(IUserRoleRepositoryService repository,
        ICacheService<UserRoleEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<UserRoleEntity>?> GetUserRoleListAsync() =>
        await _repository.GetUserRoleListAsync() ?? new();

    public async Task<List<UserRoleEntity>?> GetUserRoleListAsync(string name) =>
        await _repository.GetUserRoleListAsync(name) ?? new();

    public async Task<UserRoleEntity?> GetUserRoleAsync(int id)
    {
        if (_cache.TryGet(id, out var userRole))
            return userRole;

        userRole = await _repository.GetUserRoleAsync(id);

        return userRole is null ? null : _cache.Set(key: id, value: userRole);
    }

    public async Task CreateAsync(UserRoleEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(UserRoleEntity entity)
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