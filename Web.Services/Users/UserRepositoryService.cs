namespace Web.Services.Users;

public class UserRepositoryService : IUserRepositoryService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserRepositoryService(IMapper mapper,
        IUserRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<User> GetUserAsync(string login) =>
        _mapper.Map<User>(
            source: await _repository.GetUserAsync(login));

    public async Task<User> GetUserAsync(string login, string password) =>
        _mapper.Map<User>(
            source: await _repository.GetUserAsync(login, password));

    public async Task InsertUserAsync(User user) =>
        await _repository.InsertUserAsync(
            user: _mapper.Map<UserEntity>(source: user));
}