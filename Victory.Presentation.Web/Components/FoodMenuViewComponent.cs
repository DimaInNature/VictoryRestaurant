namespace Victory.Presentation.Web.Components;

public class FoodMenuViewComponent : ViewComponent
{
    private readonly IFoodFacadeService _foodService;

    public FoodMenuViewComponent(IFoodFacadeService foodService) => _foodService = foodService;

    public async Task<IViewComponentResult> InvokeAsync(FoodType foodType, DisplaySide side)
    {
        var foods = await _foodService.GetFoodListAsync(type: foodType);

        ViewBag.Side = side;

        ViewBag.FoodTypeMessage = foodType switch
        {
            FoodType.Breakfast => "завтрак",
            FoodType.Lunch => "обед",
            FoodType.Dinner => "ужин",
            FoodType.Dessert => "десерт",
            _ => string.Empty,
        };

        ViewBag.FoodTypeLower = foodType.ToString().ToLower();

        return View(model: foods);
    }
}