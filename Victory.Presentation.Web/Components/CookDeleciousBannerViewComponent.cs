namespace Victory.Presentation.Web.Components;

public class CookDeleciousBannerViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.Phone = DomainInfoConfiguration.Phone;

        return View();
    }
}