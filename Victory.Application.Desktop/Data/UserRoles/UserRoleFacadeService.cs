namespace Victory.Application.Desktop.Data.UserRoles;

public class UserRoleFacadeService : IUserRoleFacadeService
{
    private readonly IUserRoleRepositoryService _repository;

    public UserRoleFacadeService(IUserRoleRepositoryService repository) =>
        _repository = repository;

    public async Task<UserRole?> GetUserRoleAsync(int id, string token) =>
        await _repository.GetUserRoleAsync(id, token);

    public async Task<List<UserRole>> GetUserRoleListAsync(string token) =>
        await _repository.GetUserRoleListAsync(token) ?? new();
}