namespace Victory.Presentation.Web.Components;

public class CookDeleciousBannerViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        ViewBag.Phone = CompanyInfoConfiguration.Phone;

        return View();
    }
}