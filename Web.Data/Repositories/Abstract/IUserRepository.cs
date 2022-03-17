namespace Web.Data.Repositories.Abstract;

public interface IUserRepository
{
    Task InsertUserAsync(UserEntity user);
    Task<UserEntity> GetUserAsync(string login);
    Task<UserEntity> GetUserAsync(string login, string password);
}