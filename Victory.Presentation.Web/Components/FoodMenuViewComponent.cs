namespace Victory.Presentation.Web.Components;

public class FoodMenuViewComponent : ViewComponent
{
    private readonly IFoodFacadeService _foodService;

    public FoodMenuViewComponent(IFoodFacadeService foodService) => _foodService = foodService;

    public async Task<IViewComponentResult> InvokeAsync(string foodType, DisplaySide side)
    {
        var foods = await _foodService.GetFoodListAsync(type: new FoodType() { Name = foodType });

        ViewBag.Side = side;

        ViewBag.FoodTypeMessage = foodType;

        ViewBag.EngFoodTypeLower = foodType.ToLower();

        return View(model: foods);
    }
}