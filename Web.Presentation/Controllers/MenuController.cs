namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("Menu")]
public class MenuController : Controller
{
    [ResponseCache(CacheProfileName = "Caching")]
    [HttpGet("")]
    public IActionResult Index() => View(viewName: "Menu");
}