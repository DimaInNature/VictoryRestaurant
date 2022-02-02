namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("Contact")]
public class ContactController : Controller
{
    private readonly ILogger<ContactController> _logger;

    public ContactController(ILogger<ContactController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View(viewName: "Contact");
    }
}