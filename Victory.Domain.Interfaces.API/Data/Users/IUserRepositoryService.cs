namespace Victory.Domain.Interfaces.API.Data.Users;

public interface IUserRepositoryService
{
    Task<List<UserEntity>?> GetUserListAsync();
    Task<UserEntity?> GetUserAsync(int id);
    Task<UserEntity?> GetUserAsync(string login);
    Task<UserEntity?> GetUserAsync(string login, string password);
    Task CreateAsync(UserEntity entity);
    Task UpdateAsync(UserEntity entity);
    Task DeleteAsync(int id);
}