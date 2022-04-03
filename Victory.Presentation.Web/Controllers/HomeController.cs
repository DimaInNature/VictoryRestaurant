namespace Victory.Presentation.Web.Controllers;

[Route("/")]
[Route("Home")]
public class HomeController : Controller
{
    [ResponseCache(CacheProfileName = "Caching")]
    [HttpGet("")]
    public IActionResult Index() => View(viewName: "Index");
}