using System.ComponentModel.DataAnnotations;

namespace VictoryRestaurant.Domain;

public class User
{
    public int Id { get; set; }

    [Required]
    public string Login { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}