namespace API.Data.Repositories.Abstract;

public interface IUserRepository : IDisposable
{
    Task<List<UserEntity>> GetUsersAsync();
    Task<UserEntity> GetUserAsync(int userId);
    Task<UserEntity> GetUserAsync(string login);
    Task<UserEntity> GetUserAsync(string login, string password);
    Task InsertUserAsync(UserEntity user);
    Task UpdateUserAsync(UserEntity user);
    Task DeleteUserAsync(int userId);
    Task<int> SaveAsync();
}