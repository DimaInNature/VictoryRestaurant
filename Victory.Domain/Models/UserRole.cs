namespace Victory.Domain.Models;

public class UserRole : IAggregationModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}