using VictoryRestaurant.Enums.User;

namespace VictoryRestaurant.Domain;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}