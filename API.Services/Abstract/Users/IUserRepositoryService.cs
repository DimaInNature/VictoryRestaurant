namespace API.Services.Abstract.Users;

public interface IUserRepositoryService
{
    Task<List<UserEntity>> GetUsersAsync();
    Task<UserEntity> GetUserAsync(int userId);
    Task<UserEntity> GetUserAsync(UserEntity user);
    Task InsertUserAsync(UserEntity user);
    Task UpdateUserAsync(UserEntity user);
    Task DeleteUserAsync(int userId);
    Task<int> SaveAsync();
}