namespace VictoryRestaurant.Web.Mappers;

public static class FoodMapper
{
    public static FoodEntity ToEntity(this Food foodItem) =>
        foodItem is not null ? new()
        {
            Name = foodItem.Name,
            Description = foodItem.Description,
            CostInUSD = foodItem.CostInUSD,
            Type = foodItem.Type
        }
        : throw new ArgumentNullException($"{nameof(FoodMapper)},{nameof(foodItem)}");

    public static Food ToDomain(this FoodModel foodModel) =>
        foodModel is not null ? new()
        {
            Name = foodModel.Name,
            Description = foodModel.Description,
            CostInUSD = foodModel.CostInUSD,
            ImagePath = foodModel.ImagePath,
            Type = foodModel.Type
        }
        : throw new ArgumentNullException($"{nameof(FoodMapper)},{nameof(foodModel)}");

    public static Food ToDomain(this FoodEntity foodModel) =>
       foodModel is not null ? new()
       {
           Name = foodModel.Name,
           Description = foodModel.Description,
           CostInUSD = foodModel.CostInUSD,
           ImagePath = foodModel.ImagePath,
           Type = foodModel.Type
       }
       : throw new ArgumentNullException($"{nameof(FoodMapper)},{nameof(foodModel)}");
}