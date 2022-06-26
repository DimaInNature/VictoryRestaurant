namespace Victory.Presentation.Web.Components;

public class FoodMenuViewComponent : ViewComponent
{
    private readonly IFoodFacadeService _foodService;

    public FoodMenuViewComponent(IFoodFacadeService foodService) => _foodService = foodService;

    public async Task<IViewComponentResult> InvokeAsync(string foodType, DisplaySide side)
    {
        var foods = await _foodService.GetFoodListAsync(type: foodType);

        string engFoodType = string.Empty;

        switch (foodType)
        {
            case "Завтрак":
                engFoodType = "Breakfast";
                break;
            case "Обед":
                engFoodType = "Lunch";
                break;
            case "Ужин":
                engFoodType = "Dinner";
                break;
            default:
                break;
        }

        ViewBag.Side = side;

        ViewBag.FoodTypeMessage = foodType;

        ViewBag.EngFoodTypeLower = engFoodType.ToLower();

        return View(model: foods);
    }
}