namespace Victory.Presentation.Web.Controllers;

[Route(template: "Error")]
public class ErrorController : Controller
{
    [Route(template: "404")]
    [ResponseCache(CacheProfileName = "Caching")]
    public IActionResult PageNotFound() => View(viewName: "Error404");

    [Route(template: "500")]
    [ResponseCache(CacheProfileName = "Caching")]
    public IActionResult InternalServerError() => View(viewName: "Error500");
}