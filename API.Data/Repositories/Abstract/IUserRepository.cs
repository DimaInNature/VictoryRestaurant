namespace API.Data.Repositories.Abstract;

public interface IUserRepository : IDisposable
{
    Task<List<UserEntity>> GetUsersAsync();
    Task<UserEntity> GetUserAsync(int userId);
    Task<UserEntity> GetUserAsync(UserEntity user);
    Task InsertUserAsync(UserEntity user);
    Task UpdateUserAsync(UserEntity user);
    Task DeleteUserAsync(int userId);
    Task<int> SaveAsync();
}