namespace Victory.Application.Web.Decorators.Users;

public class UserRepositoryCacheService : IUserRepositoryService
{
    private const string NameForCaching = "User";

    private readonly IUserRepositoryService _repository;

    private readonly ISyncCacheService<User> _cache;

    public UserRepositoryCacheService(
        ISyncCacheService<User> cache,
        IUserRepositoryService repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<User>> GetUserListAsync(string token) =>
        await _repository.GetUserListAsync(token);

    public async Task<User?> GetUserAsync(string login, string token)
    {
        User? entityFromDb = await _repository.GetUserAsync(login, token);

        if (entityFromDb is null) return null;

        _cache.Set(key: $"{NameForCaching}_{entityFromDb.Id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task<User?> GetUserAsync(UserLogin userLogin)
    {
        User? entityFromDb = await _repository.GetUserAsync(userLogin);

        if (entityFromDb is null) return null;

        _cache.Set(key: $"{NameForCaching}_{entityFromDb.Id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task<User?> CreateAsync(User entity)
    {
        if (entity is null) return null;

        User? entityFromDb = await _repository.CreateAsync(entity);

        if (entityFromDb is null) return null;

        _cache.Set(key: $"{NameForCaching}_{entityFromDb.Id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task UpdateAsync(User entity, string token)
    {
        if (entity is null) return;

        await _repository.UpdateAsync(entity, token);

        _cache.Set(key: $"{NameForCaching}_{entity.Id}", value: entity);
    }

    public async Task DeleteAsync(int id, string token)
    {
        await _repository.DeleteAsync(id, token);

        _cache.Remove(key: $"{NameForCaching}_{id}");
    }
}