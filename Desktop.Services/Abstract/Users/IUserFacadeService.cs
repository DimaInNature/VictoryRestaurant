namespace Desktop.Services.Abstract.Users;

public interface IUserFacadeService
{
    Task<List<User>> GetUsersAsync();
    Task<User?> GetUserAsync(string login);
    Task<User?> GetUserAsync(string login, string password);
    Task InsertUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int userId);
}