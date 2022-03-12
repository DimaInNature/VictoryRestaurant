namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("/")]
[Route("Home")]
public class HomeController : Controller
{
    private readonly IFoodFacadeService _foodsService;
    private readonly IBookingFacaceService _bookingService;

    public HomeController(IFoodFacadeService foodsService,
        IBookingFacaceService bookingService)
    {
        _foodsService = foodsService;
        _bookingService = bookingService;
    }

    [ResponseCache(CacheProfileName = "Caching")]
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