using System.Net.NetworkInformation;
using Victory.Restaurant.Services.Server;
using VictoryRestaurant.Domain;

namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("/")]
[Route("Home")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IFoodFacadeService _foodsService;
    private readonly ServerHTTPClientService _httpClientService;

    public HomeController(ILogger<HomeController> logger,
        IFoodFacadeService foodsService)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _foodsService = foodsService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        ViewBag.WeeklyBreakfastFood = await _foodsService
                .GetFoodByFootTypeAsync(type: FoodType.Breakfast);

        ViewBag.WeeklyLunchFood = await _foodsService
           .GetFoodByFootTypeAsync(type: FoodType.Lunch);

        ViewBag.WeeklyDinnerFood = await _foodsService
            .GetFoodByFootTypeAsync(type: FoodType.Dinner);

        return View(viewName: "Index");
    }
}