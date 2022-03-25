namespace API.Services.Abstract.Users;

public interface IUserRepositoryService
{
    Task<List<UserEntity>?> GetUserListAsync();
    Task<UserEntity?> GetUserAsync(int userId);
    Task<UserEntity?> GetUserAsync(string login);
    Task<UserEntity?> GetUserAsync(string login, string password);
    Task CreateAsync(UserEntity user);
    Task UpdateAsync(UserEntity user);
    Task DeleteAsync(int userId);
}