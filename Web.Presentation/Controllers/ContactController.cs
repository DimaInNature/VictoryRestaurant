namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("Contact")]
public class ContactController : Controller
{
    [ResponseCache(CacheProfileName = "Caching")]
    [HttpGet("")]
    public IActionResult Index() => View(viewName: "Contact");
}