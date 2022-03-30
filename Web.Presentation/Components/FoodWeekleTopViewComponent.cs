namespace Web.Presentation.Components;

public class FoodWeekleTopViewComponent : ViewComponent
{
    private readonly IFoodFacadeService _foodsService;

    public FoodWeekleTopViewComponent(IFoodFacadeService foodsService) =>
        _foodsService = foodsService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        ViewBag.WeeklyBreakfastFood = await _foodsService
               .GetFoodByFootTypeAsync(type: FoodType.Breakfast);

        ViewBag.WeeklyLunchFood = await _foodsService
           .GetFoodByFootTypeAsync(type: FoodType.Lunch);

        ViewBag.WeeklyDinnerFood = await _foodsService
            .GetFoodByFootTypeAsync(type: FoodType.Dinner);

        return View();
    }
}