namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("Menu")]
public class MenuController : Controller
{
    private readonly ILogger<MenuController> _logger;
    private readonly IFoodFacadeService _foodService;

    public MenuController(ILogger<MenuController> logger, IFoodFacadeService foodService)
    {
        _logger = logger;
        _foodService = foodService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        ViewBag.BreakfastFoods = await _foodService
            .GetAllByFoodType(type: FoodType.Breakfast);

        ViewBag.LunchFoods = await _foodService
            .GetAllByFoodType(type: FoodType.Lunch);

        ViewBag.DinnerFoods = await _foodService
            .GetAllByFoodType(type: FoodType.Dinner);

        return View(viewName: "Menu");
    }
}