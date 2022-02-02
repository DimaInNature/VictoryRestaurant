namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("/")]
[Route("Home")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFoodFacadeService _foodsService;

    public HomeController(ILogger<HomeController> logger, IFoodFacadeService foodsService)
    {
        _logger = logger;
        _foodsService = foodsService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        ViewBag.WeeklyBreakfastFood = _foodsService
            .GetFirstFood(predicate: food => food.Type is FoodType.Breakfast);

        ViewBag.WeeklyLunchFood = _foodsService
            .GetFirstFood(predicate: food => food.Type is FoodType.Lunch);

        ViewBag.WeeklyDinnerFood = _foodsService
            .GetFirstFood(predicate: food => food.Type is FoodType.Dinner);

        return View(viewName: "Index");
    }
}