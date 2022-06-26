namespace Victory.Application.General.Client.Interfaces.Data.UserRoles;

public interface IUserRoleRepositoryService
{
    Task<List<UserRole>?> GetUserRoleListAsync();
    Task<UserRole?> GetUserRoleAsync(int id);
}