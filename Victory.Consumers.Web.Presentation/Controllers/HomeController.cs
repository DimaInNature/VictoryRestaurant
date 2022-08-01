namespace Victory.Consumers.Web.Presentation.Controllers;

[Route(template: "/")]
[Route(template: "Home")]
public class HomeController : Controller
{
    [ResponseCache(CacheProfileName = "Caching")]
    [HttpGet(template: "")]
    public IActionResult Index() => View(viewName: "Index");
}