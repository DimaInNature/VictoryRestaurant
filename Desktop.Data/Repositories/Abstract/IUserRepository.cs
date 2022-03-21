namespace Desktop.Data.Repositories.Abstract;

public interface IUserRepository : IDisposable
{
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserAsync(string login, string password);
    Task InsertUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int userId);
}