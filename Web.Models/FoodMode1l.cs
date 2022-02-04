using VictoryRestaurant.Web.Enums;

namespace VictoryRestaurant.Web.Models;

public class FoodModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double CostInUSD { get; set; }
    public string ImagePath { get; set; }
    public FoodType Type { get; set; }
}