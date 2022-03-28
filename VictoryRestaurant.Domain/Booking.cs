using System.ComponentModel.DataAnnotations;
using VictoryRestaurant.Domain.Abstract;

namespace VictoryRestaurant.Domain;

public class Booking : IDomainModel
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