namespace Victory.Application.Desktop.Data.UserRoles;

public class UserRoleFacadeService : IUserRoleFacadeService
{
    private readonly IUserRoleRepositoryService _repository;

    public UserRoleFacadeService(IUserRoleRepositoryService repository) =>
        _repository = repository;

    public async Task<UserRole?> GetUserRoleAsync(int id) =>
        await _repository.GetUserRoleAsync(id);

    public async Task<List<UserRole>> GetUserRoleListAsync() =>
        await _repository.GetUserRoleListAsync() ?? new();
}