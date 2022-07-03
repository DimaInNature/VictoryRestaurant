namespace Victory.Domain.Interfaces.Clients.Data.Tables;

public interface ITableRepositoryService
{
    Task<List<Table>> GetTableListAsync();
    Task<List<Table>> GetTableListAsync(int number);
    Task<List<Table>> GetTableListAsync(string status);
    Task<Table?> GetTableAsync(int id);
    Task CreateAsync(Table entity);
    Task UpdateAsync(Table entity);
    Task DeleteAsync(int id);
}