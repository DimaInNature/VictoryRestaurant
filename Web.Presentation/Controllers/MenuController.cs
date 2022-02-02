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
    public IActionResult Index()
    {
        ViewBag.BreakfastFoods = _foodService
            .GetAllFoods(predicate: food => food.Type is FoodType.Breakfast);

        ViewBag.LunchFoods = _foodService
            .GetAllFoods(predicate: food => food.Type is FoodType.Lunch);

        ViewBag.DinnerFoods = _foodService
            .GetAllFoods(predicate: food => food.Type is FoodType.Dinner);

        return View(viewName: "Menu");
    }
}