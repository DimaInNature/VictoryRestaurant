namespace Victory.Application.API.Data.Users;

public class UserFacadeService : IUserFacadeService
{
    private const string NameForCaching = "User";

    private readonly IUserRepositoryService _repository;

    private readonly ICacheService<UserEntity> _cache;

    public UserFacadeService(ICacheService<UserEntity> cache,
        IUserRepositoryService repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<UserEntity>> GetUserListAsync() =>
        await _repository.GetUserListAsync() ?? new();

    public async Task<UserEntity?> GetUserAsync(string login)
    {
        UserEntity? entity = await _repository.GetUserAsync(login);

        if (entity is null) return null;

        await _cache.SetAsync(key: $"{NameForCaching}_{entity.Id}", value: entity);

        return entity;
    }

    public async Task<UserEntity?> GetUserAsync(UserLogin userLogin)
    {
        UserEntity? entity = await _repository.GetUserAsync(userLogin);

        if (entity is null) return null;

        await _cache.SetAsync(key: $"{NameForCaching}_{entity.Id}", value: entity);

        return entity;
    }

    public async Task<UserEntity?> GetUserAsync(int id)
    {
        UserEntity? entityFromCache = await _cache.GetAsync(key: $"{NameForCaching}_{id}");

        if (entityFromCache is not null) return entityFromCache;

        UserEntity? entityFromDb = await _repository.GetUserAsync(id);

        if (entityFromDb is null) return null;

        await _cache.SetAsync(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task CreateAsync(UserEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UserEntity entity)
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