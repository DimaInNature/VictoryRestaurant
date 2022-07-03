namespace Victory.Domain.Interfaces.API.Data.UserRoles;

public interface IUserRoleFacadeService
{
    Task<List<UserRoleEntity>?> GetUserRoleListAsync();
    Task<List<UserRoleEntity>?> GetUserRoleListAsync(string name);
    Task<UserRoleEntity?> GetUserRoleAsync(int id);
    Task CreateAsync(UserRoleEntity entity);
    Task UpdateAsync(UserRoleEntity entity);
    Task DeleteAsync(int id);
}