namespace Victory.Domain.API.Decorators.UserRoles;

public class UserRoleRepositoryCacheService : IUserRoleRepositoryService
{
    private const string NameForCaching = "UserRole";

    private readonly IUserRoleRepositoryService _repository;

    private readonly IAsyncCacheService<UserRoleEntity> _cache;

    public UserRoleRepositoryCacheService(IUserRoleRepositoryService repository,
        IAsyncCacheService<UserRoleEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<UserRoleEntity>?> GetUserRoleListAsync() =>
        await _repository.GetUserRoleListAsync() ?? new();

    public async Task<List<UserRoleEntity>?> GetUserRoleListAsync(string name) =>
        await _repository.GetUserRoleListAsync(name) ?? new();

    public async Task<UserRoleEntity?> GetUserRoleAsync(int id)
    {
        UserRoleEntity? entityFromCache = await _cache.GetAsync(key: $"{NameForCaching}_{id}");

        if (entityFromCache is not null) return entityFromCache;

        UserRoleEntity? entityFromDb = await _repository.GetUserRoleAsync(id);

        if (entityFromDb is null) return null;

        await _cache.SetAsync(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task CreateAsync(UserRoleEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UserRoleEntity entity)
    {
        if (entity is null) return;

        await _cache.SetAsync(key: $"{NameForCaching}_{entity.Id}", value: entity);

        await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);

        await _cache.RemoveAsync(key: $"{NameForCaching}_{id}");
    }
}