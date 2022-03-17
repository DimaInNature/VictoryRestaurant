namespace Web.Services.Abstract.Users;

public interface IUserRepositoryService
{
    Task InsertUserAsync(User user);
    Task<User> GetUserAsync(string login);
    Task<User> GetUserAsync(string login, string password);
}