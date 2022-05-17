namespace Victory.Application.Web.Interfaces.Data.Users;

public interface IUserFacadeService
{
    Task CreateAsync(User entity);
    Task<User?> GetUserAsync(string login);
    Task<User?> GetUserAsync(string login, string password);
}