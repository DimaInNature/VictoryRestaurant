namespace Victory.Application.API.Data.Tables;

public class TableFacadeService : ITableFacadeService
{
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
        if (_cache.TryGet(id, out var Table))
            return Table;

        Table = await _repository.GetTableAsync(id);

        return Table is null ? null : _cache.Set(key: id, value: Table);
    }

    public async Task CreateAsync(TableEntity entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(TableEntity entity)
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