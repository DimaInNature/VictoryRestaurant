namespace Web.Presentation.Components;

public class DownloadAppViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(string fileName)
    {
        ViewBag.FileName = fileName;
        return View();
    }
}