namespace Victory.Consumers.Web.Presentation.Components;

public class FoodMenuViewComponent : ViewComponent
{
    private readonly IFoodService _foodService;

    public FoodMenuViewComponent(IFoodService foodService) => _foodService = foodService;

    public async Task<IViewComponentResult> InvokeAsync(string foodType, DisplaySide side)
    {
        var foods = await _foodService.GetFoodListAsync(type: new FoodType() { Name = foodType });

        ViewBag.Side = side;

        ViewBag.FoodTypeMessage = foodType;

        ViewBag.EngFoodTypeLower = foodType.ToLower();

        return View(model: foods);
    }
}