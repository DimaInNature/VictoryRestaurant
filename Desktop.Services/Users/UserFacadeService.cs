namespace Desktop.Services.Users;

public sealed class UserFacadeService : IUserFacadeService
{
    private readonly IUserRepositoryService _repository;

    public UserFacadeService(IUserRepositoryService repository)
    {
        _repository = repository;
    }

    public async Task<List<User>> GetUserListAsync() =>
        await _repository.GetUserListAsync();

    public async Task<User?> GetUserAsync(string login) =>
        await _repository.GetUserAsync(login);

    public async Task<User?> GetUserAsync(string login, string password) =>
        await _repository.GetUserAsync(login, password);

    public async Task CreateAsync(User user) =>
        await _repository.CreateAsync(user);

    public async Task UpdateAsync(User user) =>
        await _repository.UpdateAsync(user);

    public async Task DeleteAsync(int userId) =>
        await _repository.DeleteAsync(userId);
}