namespace Victory.Application.Web.Interfaces;

public interface IUserRepositoryService
{
    Task CreateAsync(User entity);
    Task<User?> GetUserAsync(string login);
    Task<User?> GetUserAsync(string login, string password);
}