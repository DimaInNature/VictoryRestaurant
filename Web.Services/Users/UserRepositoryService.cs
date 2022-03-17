namespace Web.Services.Users;

public class UserRepositoryService : IUserRepositoryService
{
    private readonly IUserRepository _repository;

    public UserRepositoryService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> GetUserAsync(string login) =>
        await _repository.GetUserAsync(login).ToDomain();

    public async Task<User> GetUserAsync(string login, string password) =>
        await _repository.GetUserAsync(login, password).ToDomain();

    public async Task InsertUserAsync(User user) =>
        await _repository.InsertUserAsync(user.ToEntity());
}