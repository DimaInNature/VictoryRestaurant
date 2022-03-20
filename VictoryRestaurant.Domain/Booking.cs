using System.ComponentModel.DataAnnotations;

namespace VictoryRestaurant.Domain;

public class Booking
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "День недели")]
    public DayOfWeek DayOfWeek { get; set; }

    [Required]
    [Display(Name = "Время")]
    public string Time { get; set; }

    [Required]
    [Display(Name = "Имя")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Телефон")]
    public string Phone { get; set; }

    [Required]
    [Display(Name = "Количество людей")]
    public int PersonCount { get; set; }
}