namespace Victory.Microservices.FoodService.Persistence.Entities;

public class FoodTypeEntity : IDatabaseEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}