namespace Desktop.Services.Abstract.Users;

public interface IUserFacadeService
{
    Task<List<User>> GetUserListAsync();
    Task<User?> GetUserAsync(string login);
    Task<User?> GetUserAsync(string login, string password);
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(int userId);
}