namespace Victory.Application.Desktop.Data.Users;

public sealed class UserFacadeService : IUserFacadeService
{
    private readonly IUserRepositoryService _repository;

    public UserFacadeService(IUserRepositoryService repository) =>
        _repository = repository;

    public async Task<List<User>> GetUserListAsync(string token) =>
        await _repository.GetUserListAsync(token);

    public async Task<User?> GetUserAsync(string login, string token) =>
        await _repository.GetUserAsync(login, token);

    public async Task<User?> GetUserAsync(UserLogin userLogin) =>
        await _repository.GetUserAsync(userLogin);

    public async Task<User?> CreateAsync(User entity) =>
        await _repository.CreateAsync(entity);

    public async Task UpdateAsync(User entity, string token) =>
        await _repository.UpdateAsync(entity, token);

    public async Task DeleteAsync(int id, string token) =>
        await _repository.DeleteAsync(id, token);
}