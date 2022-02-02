using VictoryRestaurant.Web.Enums;

namespace VictoryRestaurant.Web.Domain;

public class Food
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double CostInUSD { get; set; }
    public string ImagePath { get; set; }
    public FoodType Type { get; set; }
}