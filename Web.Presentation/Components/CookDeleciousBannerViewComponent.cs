namespace Web.Presentation.Components;

public class CookDeleciousBannerViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.Phone = CompanyInfoConfiguration.Phone;
        return View();
    }
}