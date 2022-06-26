namespace Victory.Presentation.Web.Components;

public class PageHeadingViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(string heading, string text)
    {
        (ViewBag.Heading, ViewBag.Text) = (heading, text);

        return View();
    }
}