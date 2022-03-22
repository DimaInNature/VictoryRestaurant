namespace Desktop.Services.Users;

public sealed class UserFacadeService : IUserFacadeService
{
    private readonly IUserRepositoryService _repository;

    public UserFacadeService(IUserRepositoryService repository)
    {
        _repository = repository;
    }

    public async Task<List<User>> GetUsersAsync() =>
        await _repository.GetUsersAsync();

    public async Task<User?> GetUserAsync(string login) =>
        await _repository.GetUserAsync(login);

    public async Task<User?> GetUserAsync(string login, string password) =>
        await _repository.GetUserAsync(login, password);

    public async Task InsertUserAsync(User user) =>
        await _repository.InsertUserAsync(user);

    public async Task UpdateUserAsync(User user) =>
        await _repository.UpdateUserAsync(user);

    public async Task DeleteUserAsync(int userId) =>
        await _repository.DeleteUserAsync(userId);
}