namespace Victory.Consumers.Web.Domain.Interfaces.Tables;

public interface ITableService
{
    Task<List<Table>> GetTableListAsync();

    Task<List<Table>> GetTableListAsync(int number);

    Task<List<Table>> GetTableListAsync(string status);

    Task<Table?> GetTableAsync(int id, string token);

    Task CreateAsync(Table entity, string token);

    Task UpdateAsync(Table entity);

    Task DeleteAsync(int id, string token);
}