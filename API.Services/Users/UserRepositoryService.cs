namespace API.Services.Users;

public class UserRepositoryService : IUserRepositoryService
{
    private readonly IUserRepository _repository;

    public UserRepositoryService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserEntity>> GetUsersAsync() =>
        await _repository.GetUsersAsync();

    public async Task<UserEntity> GetUserAsync(UserEntity user) =>
        await _repository.GetUserAsync(user);

    public async Task<UserEntity> GetUserAsync(int userId) =>
        await _repository.GetUserAsync(userId);

    public async Task InsertUserAsync(UserEntity user) =>
        await _repository.InsertUserAsync(user);

    public async Task UpdateUserAsync(UserEntity user) =>
        await _repository.UpdateUserAsync(user);

    public async Task DeleteUserAsync(int userId) =>
        await _repository.DeleteUserAsync(userId);

    public async Task<int> SaveAsync() => await _repository.SaveAsync();
}