namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("Contact")]
public class ContactController : Controller
{
    [HttpGet("")]
    public IActionResult Index() => View(viewName: "Contact");
}