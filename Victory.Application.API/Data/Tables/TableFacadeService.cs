namespace Victory.Application.API.Data.Tables;

public class TableFacadeService : ITableFacadeService
{
    private const string NameForCaching = "Table";

    private readonly ITableRepositoryService _repository;

    private readonly ICacheService<TableEntity> _cache;

    public TableFacadeService(ITableRepositoryService repository,
        ICacheService<TableEntity> cache) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<TableEntity>?> GetTableListAsync() =>
        await _repository.GetTableListAsync() ?? new();

    public async Task<List<TableEntity>?> GetTableListAsync(int number) =>
        await _repository.GetTableListAsync(number) ?? new();

    public async Task<List<TableEntity>?> GetTableListAsync(string status) =>
        await _repository.GetTableListAsync(status) ?? new();

    public async Task<TableEntity?> GetTableAsync(int id)
    {
        TableEntity? entityFromCache = await _cache.GetAsync(key: $"{NameForCaching}_{id}");

        if (entityFromCache is not null) return entityFromCache;

        TableEntity? entityFromDb = await _repository.GetTableAsync(id);

        if (entityFromDb is null) return null;

        await _cache.SetAsync(key: $"{NameForCaching}_{id}", value: entityFromDb);

        return entityFromDb;
    }

    public async Task CreateAsync(TableEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);
    }

    public async Task UpdateAsync(TableEntity entity)
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