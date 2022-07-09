namespace Victory.Application.Desktop.Data.Tables;

public class TableFacadeService : ITableFacadeService
{
    private readonly ITableRepositoryService _repository;

    public TableFacadeService(ITableRepositoryService repository) => _repository = repository;

    public async Task<Table?> GetTableAsync(int id, string token) =>
        await _repository.GetTableAsync(id, token);

    public async Task<List<Table>> GetTableListAsync() =>
        await _repository.GetTableListAsync() ?? new();

    public async Task<List<Table>> GetTableListAsync(int number) =>
        await _repository.GetTableListAsync(number) ?? new();

    public async Task<List<Table>> GetTableListAsync(string status) =>
        await _repository.GetTableListAsync(status) ?? new();

    public async Task CreateAsync(Table entity, string token) =>
        await _repository.CreateAsync(entity, token);

    public async Task UpdateAsync(Table entity) =>
        await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(int id, string token) =>
        await _repository.DeleteAsync(id, token);
}