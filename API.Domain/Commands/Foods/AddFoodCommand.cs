using VictoryRestaurant.Entities;

namespace API.Domain.Commands.Foods;

public class AddFoodCommand : FoodCommand
{
    public AddFoodCommand(FoodEntity food)
    {
        Food = food;
    }
}