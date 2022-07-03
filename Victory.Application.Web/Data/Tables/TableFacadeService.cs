namespace Victory.Application.Web.Data.Tables;

public class TableFacadeService : ITableFacadeService
{
    private readonly TableRepositoryServiceLoggerDecorator _repository;

    private readonly ICacheService<Table> _cache;

    public TableFacadeService(ICacheService<Table> cache,
        TableRepositoryServiceLoggerDecorator repository) =>
        (_repository, _cache) = (repository, cache);

    public async Task<List<Table>> GetTableListAsync() =>
        await _repository.GetTableListAsync() ?? new();

    public async Task<List<Table>> GetTableListAsync(int number) =>
        await _repository.GetTableListAsync(number) ?? new();

    public async Task<List<Table>> GetTableListAsync(string status) =>
        await _repository.GetTableListAsync(status) ?? new();

    public async Task<Table?> GetTableAsync(int id)
    {
        var entity = await _repository.GetTableAsync(id);

        if (entity is null) return null;

        _cache.Set(key: entity.Id, value: entity);

        return entity;
    }

    public async Task CreateAsync(Table entity)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(Table entity)
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