namespace Victory.Consumers.Web.Application.Services.Tables;

public class TableCacheService : ITableService
{
    private const string NameForCaching = "Table";

    private readonly ITableService _repository;

    private readonly ISyncCacheService<Table> _cache;

    public TableCacheService(
        ISyncCacheService<Table> cache,
        ITableService repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<Table>> GetTableListAsync() =>
        await _repository.GetTableListAsync() ?? new();

    public async Task<List<Table>> GetTableListAsync(int number) =>
        await _repository.GetTableListAsync(number) ?? new();

    public async Task<List<Table>> GetTableListAsync(string status) =>
        await _repository.GetTableListAsync(status) ?? new();

    public async Task<Table?> GetTableAsync(int id, string token)
    {
        Table? cached = _cache.Get(key: $"{NameForCaching}_{id}");

        if (cached is not null) return cached;

        Table? entityFromDb = await _repository.GetTableAsync(id, token);

        if (entityFromDb is null) return null;

        _cache.Set(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task CreateAsync(Table entity, string token)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity, token);
    }

    public async Task UpdateAsync(Table entity)
    {
        if (entity is null) return;

        await _repository.UpdateAsync(entity);

        _cache.Set(key: $"{NameForCaching}_{entity.Id}", value: entity);
    }

    public async Task DeleteAsync(int id, string token)
    {
        await _repository.DeleteAsync(id, token);

        _cache.Remove(key: $"{NameForCaching}_{id}");
    }
}