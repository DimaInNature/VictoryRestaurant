namespace Victory.Presentation.Web.Controllers;

[Route("Contact")]
public class ContactController : Controller
{
    [ResponseCache(CacheProfileName = "Caching")]
    [HttpGet("")]
    public IActionResult Index() => View(viewName: "Contact");
}