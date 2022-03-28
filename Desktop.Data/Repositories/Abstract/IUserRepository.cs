namespace Desktop.Data.Repositories.Abstract;

public interface IUserRepository : IDisposable
{
    Task<List<User>?> GetUserListAsync();
    Task<User?> GetUserAsync(string login);
    Task<User?> GetUserAsync(string login, string password);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int userId);
}