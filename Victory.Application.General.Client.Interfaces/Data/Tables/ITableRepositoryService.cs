namespace Victory.Application.General.Client.Interfaces.Data.Tables;

public interface ITableRepositoryService
{
    Task<List<Table>> GetTableListAsync();
    Task<List<Table>> GetTableListAsync(int number);
    Task<List<Table>> GetTableListAsync(bool status);
    Task<Table?> GetTableAsync(int id);
    Task CreateAsync(Table entity);
    Task UpdateAsync(Table entity);
    Task DeleteAsync(int id);
}