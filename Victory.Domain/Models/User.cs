namespace Victory.Domain.Models;

public class User : IDomainModel
{
    public int Id { get; set; }

    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public UserRole? UserRole { get; set; }

    public int? UserRoleId { get; set; }

    public bool Equals(User user) =>
        user != null &&
        Id == user.Id &&
        Login == user.Login &&
        Password == user.Password &&
        UserRoleId == user.UserRoleId;
}