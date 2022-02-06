namespace VictoryRestaurant.Web.Mappers;

public static class FoodMapper
{
    public static FoodEntity ToEntity(this Food foodItem) =>
        foodItem is not null ? new()
        {
            Name = foodItem.Name,
            Description = foodItem.Description,
            CostInUSD = foodItem.CostInUSD,
            ImagePath = foodItem.ImagePath,
            CreatedDate = foodItem.CreatedDate,
            Id = foodItem.Id,
            Type = foodItem.Type
        }
        : throw new ArgumentNullException($"{nameof(FoodMapper)},{nameof(foodItem)}");

    public static Food ToDomain(this FoodEntity foodModel) =>
       foodModel is not null ? new()
       {
           Id = foodModel.Id,
           CreatedDate = foodModel.CreatedDate,
           Name = foodModel.Name,
           Description = foodModel.Description,
           CostInUSD = foodModel.CostInUSD,
           ImagePath = foodModel.ImagePath,
           Type = foodModel.Type
       }
       : throw new ArgumentNullException($"{nameof(FoodMapper)},{nameof(foodModel)}");

    public static async Task<Food> ToDomain(this Task<FoodEntity> foodModel) => await
      foodModel is not null ? new Food()
      {
          Name = foodModel.Result.Name,
          Description = foodModel.Result.Description,
          CostInUSD = foodModel.Result.CostInUSD,
          ImagePath = foodModel.Result.ImagePath,
          Type = foodModel.Result.Type,
          Id = foodModel.Result.Id,
          CreatedDate = foodModel.Result.CreatedDate
      }
      : throw new ArgumentNullException($"{nameof(FoodMapper)},{nameof(foodModel)}");
}