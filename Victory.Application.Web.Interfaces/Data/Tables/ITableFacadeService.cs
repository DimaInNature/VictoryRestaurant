namespace Victory.Application.Web.Interfaces.Data.Tables;

public interface ITableFacadeService
{
    Task<List<Table>> GetTableListAsync();
    Task<List<Table>> GetTableListAsync(int number);
    Task<List<Table>> GetTableListAsync(bool status);
    Task<Table?> GetTableAsync(int id);
    Task CreateAsync(Table entity);
    Task UpdateAsync(Table entity);
    Task DeleteAsync(int id);
}