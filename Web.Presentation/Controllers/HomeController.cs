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
        IFoodFacadeService foodsService, ServerHTTPClientService httpClientService)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _foodsService = foodsService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        try
        {
            var replyStatus = await _httpClientService.Ping();

            if (replyStatus is IPStatus.Success)
            {
                ViewBag.WeeklyBreakfastFood = await _foodsService
                .GetFoodByFootType(type: FoodType.Breakfast);

                ViewBag.WeeklyLunchFood = await _foodsService
                   .GetFoodByFootType(type: FoodType.Lunch);

                ViewBag.WeeklyDinnerFood = await _foodsService
                    .GetFoodByFootType(type: FoodType.Dinner);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(message: $"HomeController {ex.Message}");

            ViewBag.WeeklyBreakfastFood = new Food();

            ViewBag.WeeklyLunchFood = new Food();

            ViewBag.WeeklyDinnerFood = new Food();
        }

        return View(viewName: "Index");
    }
}