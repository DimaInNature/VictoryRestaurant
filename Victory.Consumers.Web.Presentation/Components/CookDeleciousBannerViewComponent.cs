namespace Victory.Consumers.Web.Presentation.Components;

public class CookDeleciousBannerViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.Phone = DomainInfoConfiguration.Phone;

        return View();
    }
}