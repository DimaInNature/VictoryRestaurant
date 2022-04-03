namespace Victory.Application.Desktop.Services;

public sealed class UserFacadeService : IUserFacadeService
{
    private readonly IUserRepositoryService _repository;

    public UserFacadeService(IUserRepositoryService repository) =>
        _repository = repository;

    public async Task<List<User>> GetUserListAsync() =>
        await _repository.GetUserListAsync();

    public async Task<User?> GetUserAsync(string login) =>
        await _repository.GetUserAsync(login);

    public async Task<User?> GetUserAsync(string login, string password) =>
        await _repository.GetUserAsync(login, password);

    public async Task CreateAsync(User entity) =>
        await _repository.CreateAsync(entity);

    public async Task UpdateAsync(User entity) =>
        await _repository.UpdateAsync(entity);

    public async Task DeleteAsync(int id) =>
        await _repository.DeleteAsync(id);
}