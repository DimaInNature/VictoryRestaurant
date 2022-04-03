namespace Victory.Presentation.Web.Controllers;

[Route("Menu")]
public class MenuController : Controller
{
    [ResponseCache(CacheProfileName = "Caching")]
    [HttpGet("")]
    public IActionResult Index() => View(viewName: "Menu");
}