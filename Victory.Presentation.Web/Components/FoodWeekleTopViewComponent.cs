namespace Victory.Presentation.Web.Components;

public class FoodWeekleTopViewComponent : ViewComponent
{
    private readonly IFoodFacadeService _foodsService;

    public FoodWeekleTopViewComponent(IFoodFacadeService foodsService) => _foodsService = foodsService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.WeeklyBreakfastFood = await _foodsService
               .GetFoodAsync(type: FoodType.Breakfast);

        ViewBag.WeeklyLunchFood = await _foodsService
           .GetFoodAsync(type: FoodType.Lunch);

        ViewBag.WeeklyDinnerFood = await _foodsService
            .GetFoodAsync(type: FoodType.Dinner);

        return View();
    }
}