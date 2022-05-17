namespace Victory.Application.Desktop.Interfaces.Data.Users;

public interface IUserFacadeService
{
    Task<List<User>> GetUserListAsync();
    Task<User?> GetUserAsync(string login);
    Task<User?> GetUserAsync(string login, string password);
    Task CreateAsync(User entity);
    Task UpdateAsync(User entity);
    Task DeleteAsync(int id);
}