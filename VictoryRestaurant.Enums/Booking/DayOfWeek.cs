using System.ComponentModel.DataAnnotations;

namespace VictoryRestaurant.Enums.Booking;

public enum DayOfWeek
{
    [Display(Name = "Понедельник")] Monday = 0,
    [Display(Name = "Вторник")] Tuesday = 1,
    [Display(Name = "Среда")] Wednesday = 2,
    [Display(Name = "Четверг")] Thursday = 3,
    [Display(Name = "Пятница")] Friday = 4,
    [Display(Name = "Суббота")] Saturday = 5,
    [Display(Name = "Воскресенье")] Sunday = 6
}