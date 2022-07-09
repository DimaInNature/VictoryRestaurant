namespace Victory.Domain.Interfaces.Clients.Data.Users;

public interface IUserRepositoryService
{
    Task<List<User>> GetUserListAsync(string token);
    Task<User?> GetUserAsync(string login, string token);
    Task<User?> GetUserAsync(UserLogin userLogin);
    Task<User?> CreateAsync(User entity);
    Task UpdateAsync(User entity, string token);
    Task DeleteAsync(int id, string token);
}