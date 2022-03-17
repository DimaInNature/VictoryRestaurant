namespace API.Services.Abstract.Users;

public interface IUserFacadeService
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