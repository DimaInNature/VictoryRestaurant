namespace Victory.Domain.Interfaces.Consumers.Data.UserRoles;

public interface IUserRoleFacadeService
{
    Task<List<UserRole>> GetUserRoleListAsync(string token);
    Task<UserRole?> GetUserRoleAsync(int id, string token);
}