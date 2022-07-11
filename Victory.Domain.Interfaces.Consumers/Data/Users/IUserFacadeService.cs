namespace Victory.Domain.Interfaces.Consumers.Data.Users;

public interface IUserFacadeService
{
    Task<List<User>> GetUserListAsync(string token);
    Task<User?> GetUserAsync(string login, string token);
    Task<User?> GetUserAsync(UserLogin userLogin);
    Task<User?> CreateAsync(User entity);
    Task UpdateAsync(User entity, string token);
    Task DeleteAsync(int id, string token);
}