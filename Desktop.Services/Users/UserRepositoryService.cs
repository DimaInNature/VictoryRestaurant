namespace Desktop.Services.Users;

public sealed class UserRepositoryService : IUserRepositoryService
{
    private readonly IUserRepository _repository;

    public UserRepositoryService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<User>> GetUserListAsync() =>
        await _repository.GetUserListAsync() ?? new();

    public async Task<User?> GetUserAsync(string login) =>
        await _repository.GetUserAsync(login: login ?? string.Empty);

    public async Task<User?> GetUserAsync(string login, string password) =>
        await _repository.GetUserAsync(login: login ?? string.Empty,
            password: password ?? string.Empty);

    public async Task CreateAsync(User user)
    {
        if (user is null) return;

        await _repository.CreateAsync(user);
    }

    public async Task UpdateAsync(User user)
    {
        if (user is null) return;

        await _repository.UpdateAsync(user);
    }

    public async Task DeleteAsync(int userId)
    {
        if (userId < 1) return;

        await _repository.DeleteAsync(userId);
    }
}