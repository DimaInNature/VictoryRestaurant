namespace Victory.Application.Web.Interfaces.Data.UserRoles;

public interface IUserRoleFacadeService
{
    Task<List<UserRole>> GetUserRoleListAsync();
    Task<UserRole?> GetUserRoleAsync(int id);
}