namespace Victory.Application.API.Interfaces.Data.Tables;

public interface ITableRepositoryService
{
    Task<List<TableEntity>?> GetTableListAsync();
    Task<List<TableEntity>?> GetTableListAsync(int number);
    Task<List<TableEntity>?> GetTableListAsync(string status);
    Task<TableEntity?> GetTableAsync(int id);
    Task CreateAsync(TableEntity entity);
    Task UpdateAsync(TableEntity entity);
    Task DeleteAsync(int id);
}