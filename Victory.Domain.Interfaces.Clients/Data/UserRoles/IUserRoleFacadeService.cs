namespace Victory.Domain.Interfaces.Clients.Data.UserRoles;

public interface IUserRoleFacadeService
{
    Task<List<UserRole>> GetUserRoleListAsync();
    Task<UserRole?> GetUserRoleAsync(int id);
}