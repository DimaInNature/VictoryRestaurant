using System.Net.NetworkInformation;
using Victory.Restaurant.Services.Server;
using VictoryRestaurant.Domain;

namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("Menu")]
public class MenuController : Controller
{
    private readonly ILogger<MenuController> _logger;
    private readonly IFoodFacadeService _foodService;
    private readonly ServerHTTPClientService _httpClientService;

    public MenuController(ILogger<MenuController> logger,
        IFoodFacadeService foodService, ServerHTTPClientService httpClientService)
    {
        _httpClientService = httpClientService;
        _logger = logger;
        _foodService = foodService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        try
        {
            var replyStatus = await _httpClientService.Ping();

            if (replyStatus is IPStatus.Success)
            {
                ViewBag.BreakfastFoods = await _foodService
                    .GetAllByFoodType(type: FoodType.Breakfast);

                ViewBag.LunchFoods = await _foodService
                    .GetAllByFoodType(type: FoodType.Lunch);

                ViewBag.DinnerFoods = await _foodService
                    .GetAllByFoodType(type: FoodType.Dinner);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(message: $"MenuController {ex.Message}");

            ViewBag.BreakfastFoods = new List<Food>();

            ViewBag.LunchFoods = new List<Food>();

            ViewBag.DinnerFoods = new List<Food>();
        }


        return View(viewName: "Menu");
    }
}