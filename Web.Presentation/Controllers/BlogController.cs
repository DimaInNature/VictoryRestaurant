namespace VictoryRestaurant.Web.Presentation.Controllers;

[Route("Blog")]
public class BlogController : Controller
{
    private readonly ILogger<BlogController> _logger;

    public BlogController(ILogger<BlogController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View(viewName: "Blog");
    }
}