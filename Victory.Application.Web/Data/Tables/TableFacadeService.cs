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

    public async Task<Table?> GetTableAsync(int id, string token)
    {
        var entity = await _repository.GetTableAsync(id, token);

        if (entity is null) return null;

        _cache.Set(key: entity.Id, value: entity);

        return entity;
    }

    public async Task CreateAsync(Table entity, string token)
    {
        if (entity is null) return;

        await _repository.CreateAsync(entity, token);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task UpdateAsync(Table entity)
    {
        await _repository.UpdateAsync(entity);

        _cache.Set(key: entity.Id, value: entity);
    }

    public async Task DeleteAsync(int id, string token)
    {
        await _repository.DeleteAsync(id, token);

        if (_cache.TryGet(key: id, out _))
            _cache.Remove(key: id);
    }
}