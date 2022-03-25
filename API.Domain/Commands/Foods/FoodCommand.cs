using VictoryRestaurant.Entities;

namespace API.Domain.Commands.Foods;

public abstract class FoodCommand
{
    public FoodEntity? Food { get; protected set; }
}