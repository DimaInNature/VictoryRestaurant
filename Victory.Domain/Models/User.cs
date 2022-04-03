namespace Victory.Domain.Models;

public class User : IDomainModel
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }

    public bool Equals(User user) =>
        user != null &&
        Id == user.Id &&
        Login == user.Login &&
        Password == user.Password &&
        Role == user.Role;
}