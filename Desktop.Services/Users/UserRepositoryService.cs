namespace Desktop.Services.Users;

public sealed class UserRepositoryService : IUserRepositoryService
{
    private readonly IUserRepository _repository;

    public UserRepositoryService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<User>> GetUsersAsync() =>
        await _repository.GetUsersAsync() ?? new();

    public async Task<User?> GetUserAsync(string login, string password) =>
        await _repository.GetUserAsync(
            login: login ?? string.Empty,
            password: password ?? string.Empty);

    public async Task InsertUserAsync(User user)
    {
        if (user is null) return;

        await _repository.InsertUserAsync(user);
    }

    public async Task UpdateUserAsync(User user)
    {
        if (user is null) return;

        await _repository.UpdateUserAsync(user);
    }

    public async Task DeleteUserAsync(int userId)
    {
        if (userId < 1) return;

        await _repository.DeleteUserAsync(userId);
    }
}