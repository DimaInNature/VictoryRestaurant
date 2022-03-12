namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("Menu")]
public class MenuController : Controller
{
    private readonly IFoodFacadeService _foodService;

    public MenuController(IFoodFacadeService foodService)
    {
        _foodService = foodService;
    }

    [ResponseCache(CacheProfileName = "Caching")]
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        ViewBag.BreakfastFoods = await _foodService
            .GetAllByFoodTypeAsync(type: FoodType.Breakfast);

        ViewBag.LunchFoods = await _foodService
            .GetAllByFoodTypeAsync(type: FoodType.Lunch);

        ViewBag.DinnerFoods = await _foodService
            .GetAllByFoodTypeAsync(type: FoodType.Dinner);

        return View(viewName: "Menu");
    }
}