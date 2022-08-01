namespace Victory.Consumers.Desktop.Domain.Interfaces.UserRoles;

public interface IUserRoleService
{
    Task<List<UserRole>?> GetUserRoleListAsync(string token);

    Task<UserRole?> GetUserRoleAsync(int id, string token);
}