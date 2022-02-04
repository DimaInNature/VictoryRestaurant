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
    public async Task<IActionResult> Index()
    {
        ViewBag.WeeklyBreakfastFood = await _foodsService
            .GetFoodByFootType(type: FoodType.Breakfast);

        ViewBag.WeeklyLunchFood = await _foodsService
           .GetFoodByFootType(type: FoodType.Lunch);

        ViewBag.WeeklyDinnerFood = await _foodsService
            .GetFoodByFootType(type: FoodType.Dinner);

        return View(viewName: "Index");
    }
}