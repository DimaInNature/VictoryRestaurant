namespace Victory.Consumers.Web.Presentation.Controllers;

[Route(template: "Menu")]
public class MenuController : Controller
{
    [ResponseCache(CacheProfileName = "Caching")]
    [HttpGet(template: "")]
    public IActionResult Index() => View(viewName: "Menu");
}