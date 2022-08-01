namespace Victory.Consumers.Desktop.Domain.Core.Models;

public class Food : IDomainModel
{
    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public double CostInUSD { get; set; } = 0;

    public string? ImagePath { get; set; } = string.Empty;

    public FoodType? FoodType { get; set; }

    public int? FoodTypeId { get; set; }
}