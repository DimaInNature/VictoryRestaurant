namespace VictoryRestaurant.Web.Entities;

public class FoodEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double CostInUSD { get; set; }
    public string ImagePath { get; set; }
    public FoodType Type { get; set; }
}