namespace Victory.Consumers.Web.Presentation.Controllers;

[Route(template: "Contact")]
public class ContactController : Controller
{
    [ResponseCache(CacheProfileName = "Caching")]
    [HttpGet(template: "")]
    public IActionResult Index() => View(viewName: "Contact");
}