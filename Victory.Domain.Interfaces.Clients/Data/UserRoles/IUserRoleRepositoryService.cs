namespace Victory.Domain.Interfaces.Clients.Data.UserRoles;

public interface IUserRoleRepositoryService
{
    Task<List<UserRole>?> GetUserRoleListAsync();
    Task<UserRole?> GetUserRoleAsync(int id);
}